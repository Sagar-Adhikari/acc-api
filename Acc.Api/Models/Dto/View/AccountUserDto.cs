using Acc.Api.Models.Enum;

namespace Acc.Api.Models.Dto.View;

public class AccountUserDto
{
    public Guid AccountId { get; set; }
    public string AccountName { get; set; }
    public string UserFullName { get; set; }
    
    public UserRole UserRoleId { get; set; }
}