using Event.Core.Abstract;
using Event.Core.Helpers;
using Event.Data.Concrete;
using Event.Data.Datas.Concrete;
using Event.Data.Enums;
using Event.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Concrete
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IApplicationUser _applicationUser;

        public RepositoryBase(DbContext dbContext, IApplicationUser applicationUser)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
            _applicationUser = applicationUser;
        }

        public async Task<TEntity> AddSync(TEntity Entity)
        {
            Entity entity = setCreatedBy(Entity);

            EntityEntry result = await _dbSet.AddAsync(entity as TEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity as TEntity;

        }

        public void Delete(TEntity entity)
        {
            //Entity deletedEntity = setCreatedByAndDelete(entity);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(object EntityId)
        {
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(EntityId);
            Delete(entityToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, string include = null)
        {

            var result = typeof(TEntity).Assembly;
            var result2 = nameof(TEntity);

            return filter == null ? _dbSet.Include(include) : _dbSet.Where(filter).Include(include);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var result = await _dbSet.FirstOrDefaultAsync(filter);
            return result;
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {

            TEntity entity = await _dbSet.FindAsync(Id);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            var value = setModifiedBy(entity);

            var result = typeof(TEntity).Assembly;

            _dbSet.Update(value as TEntity);
            _dbContext.SaveChanges();
        }


        private Entity setCreatedBy(TEntity entity)
        {
            var value = entity as Entity;

            value.CreatedBy = _applicationUser.Id;
            value.CreatedAt = new DateTime();
            return value;
        }

        private Entity setCreatedByAndDelete(TEntity entity)
        {
            var value = entity as Entity;
            value.CreatedBy = _applicationUser.Id;
            value.State = EnumState.Deleted;
            value.ModifiedAt = new DateTime();
            return value;
        }

        private Entity setModifiedBy(TEntity entity)
        {
            var value = entity as Entity;
            value.ModifiedBy = _applicationUser.Id;
            value.State = EnumState.Deleted;
            value.ModifiedAt = new DateTime();
            return value;
        }
    }
}
