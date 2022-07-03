using Domain.Common;

namespace Application.Contracts.Repositories.WriteRepositories
{
    public interface IGenericWriteRepository<TEntity> where TEntity : class, IEntity, new()
    {

        Task<TEntity> AddAsync(TEntity entity);

        void Remove(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
