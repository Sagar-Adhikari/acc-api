using System.Security.Claims;
using Acc.Api.Services;

namespace Acc.Api.ExtensionMethods;

public static class ClaimsPrincipalExtensionMethods
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(userId!);
    }
    
    public static Guid GetAccountId(this ClaimsPrincipal user)
    {
        var accountId = user.FindFirstValue(AuthService.AccountIdClaimType);
        return Guid.Parse(accountId!);
    }

}