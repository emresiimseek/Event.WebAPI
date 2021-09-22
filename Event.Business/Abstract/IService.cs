using Event.Data.Datas.Abstract;
using Event.Entities;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface IService<TEntity> where TEntity : class, IEntity, new()
    {
        public abstract Task<Entities.IServiceResponseModel<TEntity>> AddAsync(TEntity Entity);
        public abstract void Update(TEntity Entity);
        public abstract void Delete(TEntity Entity);
        public abstract void DeleteById(object EntityId);
        public Task<Entities.IServiceResponseModel<TEntity>> GetByIdAsync(int id);
        public abstract Task<ServiceResponseModel<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        public abstract Task<Entities.IServiceResponseModel<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
