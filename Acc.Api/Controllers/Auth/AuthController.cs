using Acc.Api.ExtensionMethods;
using Acc.Api.Models.Dto.View;
using Acc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Acc.Api.Controllers.Auth;

public class AuthController : Controller
{

    private readonly IAccountUserService _accountUserService;
    private readonly IAuthService _authService;
    
    public AuthController(IAccountUserService accountUserService, IAuthService authService)
    {
        _accountUserService = accountUserService;
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModelDto vm)
    {
        var result = await _authService.Login(vm);
        return RedirectToAction("SelectAccount");

    }

    [Authorize]
    public async Task<IActionResult> SelectAccount()
    {   
        var accounts = await _accountUserService.ListByUser(User.GetUserId());
        if (accounts.Any())
        {
            return View(new SelectAccountDto { Accounts = accounts } );
        }
        return RedirectToAction("RegisterAccount", "Register");
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> SelectAccount(AccountUserDto accountUserDto)
    {
        await _authService.SetCurrentAccount(accountUserDto.AccountId);
        return RedirectToAction("Index","Home");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}