using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface IService<TEntity>
    {
        public abstract Task<TEntity> AddAsync(TEntity Entity);
        public abstract void Update(TEntity Entity);
        public abstract void Delete(TEntity Entity);
        public abstract void DeleteById(object EntityId);
        public abstract Task<TEntity> GetByIdAsync(int id);
        public abstract Task<TEntity> GetAsync();
        public abstract IEnumerable<TEntity> GetAll();
    }
}
