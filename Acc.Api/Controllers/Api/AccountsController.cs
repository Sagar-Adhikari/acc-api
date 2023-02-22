using Acc.Api.Models.Dto;
using Acc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Acc.Api.Controllers.Api;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService; 
    
    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<IEnumerable<AccountDto>> List()
    {
        return await _accountService.List();
    }
    
    [HttpPost]
    public async Task<AccountDto> Create(AccountCreateDto dto)
    {
        return await _accountService.Create(dto);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
          await _accountService.Delete(id);
          return Ok();
    }
}
 