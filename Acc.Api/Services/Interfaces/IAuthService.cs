using Acc.Api.Models.Dto;
using Acc.Api.Models.Dto.View;
using Acc.Api.Models.Entity;

namespace Acc.Api.Services.Interfaces;

public interface IAuthService 
{
    Task<UserDto> Register(UserRegisterViewModelDto user);
    Task<bool> Login(LoginViewModelDto loginVm);

    Task<bool> SetCurrentAccount(Guid accountId);
    Task<AccountUser> GetCurrentAccountUser();
}