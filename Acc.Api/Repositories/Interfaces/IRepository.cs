using Acc.Api.Models.Entity;

namespace Acc.Api.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> List();
    Task<TEntity> Get(Guid id);
    Task<TEntity> Create(TEntity accountUser);
    Task Delete(Guid id);
}