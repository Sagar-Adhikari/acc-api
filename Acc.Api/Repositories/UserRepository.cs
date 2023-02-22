using Acc.Api.Data;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Acc.Api.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IDbContextFactory<AccDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
    
    public async Task<User> GetByEmail(string login)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        return await context.Users.FirstOrDefaultAsync(_ =>
            _.Email.ToLower() == login.ToLower() || _.Phone.ToLower() == login.ToLower());
    }
}