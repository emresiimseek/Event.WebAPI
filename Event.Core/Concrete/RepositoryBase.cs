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
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Concrete
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;
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
            Entity deletedEntity = setCreatedByAndDelete(entity);
            Update(entity as TEntity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(object EntityId)
        {
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(EntityId);
            Delete(entityToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null ? _dbSet : _dbSet.Where(filter).Where(e => (e as Entity).State != EnumState.Deleted);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
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
