using Acc.Api.Models.Entity;

namespace Acc.Api.Repositories.Interfaces;

public interface IAccountUserRepository : IRepository<AccountUser>
{
    Task<AccountUser> Get(Guid userId, Guid accountId);
    Task<List<AccountUser>> ListByUser(Guid userId);
}