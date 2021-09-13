using Event.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Concrete
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddSync(TEntity Entity)
        {
            EntityEntry result = await _dbSet.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity as TEntity;

        }

        public void Delete(TEntity Entity)
        {
            _dbSet.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(object EntityId)
        {
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(EntityId);
            Delete(entityToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? _dbSet : _dbSet.Where(filter);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = await _dbSet.SingleOrDefaultAsync(filter);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            TEntity entity = await _dbSet.FindAsync(Id);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Update(TEntity Entity)
        {
            _dbSet.Update(Entity);
            _dbContext.SaveChanges();
        }
    }
}
