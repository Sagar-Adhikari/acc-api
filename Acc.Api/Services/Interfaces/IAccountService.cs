using Acc.Api.Models.Dto;

namespace Acc.Api.Services.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<AccountDto>> List();

    Task<AccountDto> Create(AccountCreateDto account);

    Task Delete(Guid id);
}