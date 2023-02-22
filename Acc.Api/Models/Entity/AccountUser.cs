using Acc.Api.Models.Enum;
using Acc.Api.Models.Enum.Lookup;

namespace Acc.Api.Models.Entity;

public class AccountUser : EntityBase
{
    public Guid AccountId { get; set; }
    public virtual Account Account { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public UserRole UserRoleId { get; set; }
    public virtual UserRoleLookup UserRole { get; set; } 
}