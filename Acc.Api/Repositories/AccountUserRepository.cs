using Acc.Api.Data;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Acc.Api.Repositories;

public class AccountUserRepository : Repository<AccountUser>,IAccountUserRepository
{
    public AccountUserRepository(IDbContextFactory<AccDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }

    public override async Task<AccountUser> Create(AccountUser accountUser)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            await context.Accounts.AddAsync(accountUser.Account);
            await context.SaveChangesAsync();
            await context.AccountUsers.AddAsync(accountUser);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return accountUser;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<AccountUser> Get(Guid userId, Guid accountId)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        return await context.AccountUsers
            .Include(_ => _.Account)
            .Include(_ => _.User)
            .FirstOrDefaultAsync(_ => _.UserId == userId && _.AccountId == accountId);
    }

    public async Task<List<AccountUser>> ListByUser(Guid userId)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        return await context.AccountUsers
            .Include(_ => _.Account)
            .Where(_ => _.UserId == userId).ToListAsync();
    }
}