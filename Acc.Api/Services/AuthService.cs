using System.Resources;
using System.Security.Claims;
using Acc.Api.ExtensionMethods;
using Acc.Api.Models.Dto;
using Acc.Api.Models.Dto.View;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Acc.Api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Acc.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly HttpContext _httpContext;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IAccountUserRepository _accountUserRepository; 
    public static readonly string AccountIdClaimType = "AccountId";
    
    public AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository repository, IMapper mapper, IAccountUserRepository accountUserRepository)
    {
        _httpContext = httpContextAccessor.HttpContext;
        _repository = repository;
        _passwordHasher = new PasswordHasher<User>();
        _mapper = mapper;
        _accountUserRepository = accountUserRepository;
    }

    public async Task<UserDto> Register(UserRegisterViewModelDto userVm)
    {
        var createUser = _mapper.Map<User>(userVm);
        createUser.Password = _passwordHasher.HashPassword(createUser, createUser.Password);
        var user = await _repository.Create(createUser);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> Login(LoginViewModelDto loginVm)
    {
        var user = await  _repository.GetByEmail(loginVm.Email);
        if (user == null)
        {
            throw new MissingManifestResourceException("Email not registered!");
        }
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, loginVm.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            throw new BadHttpRequestException("Invalid password!");
        }
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        var principal = new ClaimsPrincipal(identity); 
        await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(30),
            });
        return true;
    }

    public async Task<bool> SetCurrentAccount(Guid accountId)
    {
        var accountUser = await _accountUserRepository.Get(userId: _httpContext.User.GetUserId(), accountId: accountId);
        if (accountUser == null)
        {
            throw new ArgumentNullException(nameof(accountId));
        }
        try
        {
            var identity = (ClaimsIdentity)_httpContext.User.Identity;
            if (identity == null)
                return false;
            
            identity.TryRemoveClaim(identity.FindFirst(_ => _.Type == AccountIdClaimType));
            identity.AddClaim(new Claim(AccountIdClaimType, accountUser.AccountId.ToString()));
            
            identity.TryRemoveClaim(identity.FindFirst(_ => _.Type == ClaimTypes.Role));
            identity.AddClaim(new Claim(ClaimTypes.Role, accountUser.UserRoleId.ToString()));
            
            var principal = new ClaimsPrincipal(identity);
            await _httpContext.SignInAsync(principal);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<AccountUser> GetCurrentAccountUser()
    {
        var userId =  _httpContext.User.GetUserId();
        var accountId = _httpContext.User.GetAccountId();
        return await _accountUserRepository.Get(userId, accountId);
    }
}