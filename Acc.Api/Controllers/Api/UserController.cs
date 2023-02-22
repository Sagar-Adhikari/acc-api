using Acc.Api.Models.Dto;
using Acc.Api.Models.Dto.View;
using Acc.Api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Acc.Api.Controllers.Api;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UserController( IUserService userService, IAuthService authService, IMapper mapper)
    {
        _userService = userService;
        _authService = authService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDto>> List()
    {
        return await _userService.List();
    }

    [HttpGet("me")]
    public async Task<AccountUserDto> GeMe()
    {
        return _mapper.Map<AccountUserDto>(await _authService.GetCurrentAccountUser());
    }

    [HttpPost]
    public async Task<UserDto> Create(UserCreateDto dto)
    {
        return await _userService.Create(dto);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _userService.Delete(id);
        return Ok();
    }
}