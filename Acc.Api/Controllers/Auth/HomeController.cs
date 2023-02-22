using Acc.Api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Acc.Api.Controllers.Auth;
[Authorize]
public class HomeController : Controller
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;

    public HomeController(IAuthService authService, IMapper mapper, IConfiguration configuration)
    {
        _authService = authService;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<IActionResult>Index()
    {
        // var accountUser = await _authService.GetCurrentAccountUser();
        // return View(_mapper.Map<AccountUserDto>(accountUser));
        var appUrl = $"{_configuration["AppUrl"]}/";
        return Redirect(appUrl);
    }
}