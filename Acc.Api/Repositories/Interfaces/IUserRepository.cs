using Acc.Api.Models.Entity;

namespace Acc.Api.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public Task<User> GetByEmail(string login);
}