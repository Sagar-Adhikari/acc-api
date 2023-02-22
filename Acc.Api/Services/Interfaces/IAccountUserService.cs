using Acc.Api.Models.Dto.View;
using Acc.Api.Models.Entity;

namespace Acc.Api.Services.Interfaces;

public interface IAccountUserService
{
    Task<AccountUser> Create(AccountUser accountUser);
    Task<List<AccountUserDto>> ListByUser(Guid userId);
}