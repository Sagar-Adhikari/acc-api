using Acc.Api.ExtensionMethods;
using Acc.Api.Models.Dto.View;
using Acc.Api.Models.Entity;
using Acc.Api.Models.Enum;
using Acc.Api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Acc.Api.Controllers.Auth;

public class RegisterController : Controller
{
    private readonly IAuthService _authService;
    private readonly IAccountUserService _accountUserService;
    private readonly IMapper _mapper;

    public RegisterController(IUserService userService, IAccountUserService accountUserService, IMapper mapper, IAuthService authService)
    {
        _accountUserService = accountUserService;
        _mapper = mapper;
        _authService = authService;
    }

    public IActionResult RegisterUser()
    {
        return View(new UserRegisterViewModelDto());
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserRegisterViewModelDto vm)
    {
        var user = await _authService.Register(vm);
        ViewBag.Message = "Successfully registered user.";
        return RedirectToAction("Login","Auth");
    }
    
    [Authorize]
    public IActionResult RegisterAccount()
    {
        return View(new AccountRegisterDto());
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> RegisterAccount(AccountRegisterDto vm)
    {
        var account = _mapper.Map<Account>(vm);
        var userId = User.GetUserId();
       
        var result = await _accountUserService.Create(new AccountUser
        {
            Account = account,
            UserId = userId,
            UserRoleId = UserRole.Admin
        });
        if (result == null)
        {
            return BadRequest("Failed to setup account!");
        }
        return RedirectToAction("Index", "Home");
    }
}
