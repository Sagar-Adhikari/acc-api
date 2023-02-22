using Acc.Api.Models.Dto.View;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Acc.Api.Services.Interfaces;
using AutoMapper;

namespace Acc.Api.Services;

public class AccountUserService : IAccountUserService
{
    private readonly IAccountUserRepository _repository;
    private readonly IMapper _mapper;

    public AccountUserService(IAccountUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AccountUser> Create(AccountUser accountUser)
    {
       return await _repository.Create(accountUser);
    }

    public async Task<List<AccountUserDto>> ListByUser(Guid userId)
    {
        var accountUsers = await _repository.ListByUser(userId);
        var accountDto = _mapper.Map<List<AccountUserDto>>(accountUsers);
        return accountDto;
    }
}