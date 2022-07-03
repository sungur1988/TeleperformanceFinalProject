using Application.Contracts.Repositories.WriteRepositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.WriteRepositories
{
    public class GenericWriteRepository<TEntity> : IGenericWriteRepository<TEntity>
         where TEntity : class, IEntity, new()
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericWriteRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
