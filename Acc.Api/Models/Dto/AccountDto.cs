namespace Acc.Api.Models.Dto;

public class AccountDto : AccountCreateDto 
{
    public Guid Id { get; set; }
}

public class AccountCreateDto 
{
    public string Name { get; set; }
}