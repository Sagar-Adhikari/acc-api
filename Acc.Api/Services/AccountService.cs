using Acc.Api.Models.Dto;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Acc.Api.Services.Interfaces;
using AutoMapper;

namespace Acc.Api.Services;

public class AccountService : IAccountService
{
    private readonly IRepository<Account> _repository;
    

    private readonly IMapper _mapper;

    public AccountService(IRepository<Account> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AccountDto>> List()
    {
        var accounts = await _repository.List();
        var accountList = _mapper.Map<List<AccountDto>>(accounts);
        return accountList;
    }
    
    public async Task<AccountDto> Create(AccountCreateDto account)
    {
        var newAccount = _mapper.Map<Account>(account);
        var createAccount = await _repository.Create(newAccount);
        return _mapper.Map<AccountDto>(createAccount);
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
    }
}