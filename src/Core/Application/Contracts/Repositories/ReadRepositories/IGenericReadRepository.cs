using Domain.Common;
using System.Linq.Expressions;

namespace Application.Contracts.Repositories.ReadRepositories
{
    public interface IGenericReadRepository<TEntity> where TEntity : class, IEntity, new()
    {

        Task<TEntity> GetById(string id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    }
}
