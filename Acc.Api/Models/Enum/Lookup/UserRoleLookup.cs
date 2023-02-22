using System.ComponentModel.DataAnnotations.Schema;

namespace Acc.Api.Models.Enum.Lookup;

[Table("user_roles")]
public class UserRoleLookup : EnumLookupBase<UserRole>
{
}