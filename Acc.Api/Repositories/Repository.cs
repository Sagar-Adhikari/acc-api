using Acc.Api.Data;
using Acc.Api.Models.Entity;
using Acc.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Acc.Api.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    protected readonly IDbContextFactory<AccDbContext> DbContextFactory;

    public Repository(IDbContextFactory<AccDbContext> dbContextFactory)
    {
        DbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<TEntity>> List()
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        var entities = context.Set<TEntity>();
        return await entities.ToListAsync();
    }

    public async Task<TEntity> Get(Guid id)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        var entities = context.Set<TEntity>();
        return await entities.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public virtual async Task<TEntity> Create(TEntity entity)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        var entities = context.Set<TEntity>();
        await entities.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Guid id)
    {
        await using var context = await DbContextFactory.CreateDbContextAsync();
        var entities = context.Set<TEntity>();
        entities.RemoveRange(entities.Where(_ => _.Id == id));
        await context.SaveChangesAsync();
    }
}