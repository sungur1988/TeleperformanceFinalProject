using Application.Contracts.Repositories.ReadRepositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReadRepositories
{
    public class GenericReadRepository<TEntity> : IGenericReadRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericReadRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? _dbSet.AsQueryable()
                : _dbSet.Where(predicate).AsQueryable();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
