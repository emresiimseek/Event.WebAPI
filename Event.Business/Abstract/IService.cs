using Event.Entities;
using Event.Entities.Abstract;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
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
        public abstract Task<TEntity> GetAsync();
        public abstract Task<Entities.IServiceResponseModel<TEntity>> GetAll();
    }
}
