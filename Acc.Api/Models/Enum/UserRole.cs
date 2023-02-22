using System.ComponentModel;

namespace Acc.Api.Models.Enum;

public enum UserRole
{
    [Description("Normal User")]
    User = 0,
    [Description("Admin User")]
    Admin = 1000
}