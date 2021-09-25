using Event.Business.Abstract;
using Event.DataAccsess.Abstract;
using Event.Entities;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Concete
{
    public class CategoryService : ICategoryService
    {

        private ICategoryDal _categoryDal { get; set; }
        private IServiceResponseModel<Category> _serviceResponseModel { get; set; }

        public CategoryService(ICategoryDal categoryDal, IServiceResponseModel<Category> serviceResponseModel)
        {
            _categoryDal = categoryDal;
            _serviceResponseModel = serviceResponseModel;
        }


        public async Task<Category> AddAsync(Category Entity)
        {
            return await _categoryDal.AddSync(Entity);
        }

        public void Delete(Category Entity)
        {
            _categoryDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _categoryDal.DeleteById(EntityId);
        }

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return  _categoryDal.GetAll(filter).ToList();
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> filter = null)
        {
            return await _categoryDal.GetAsync(filter);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryDal.GetByIdAsync(id);

        }

        public void Update(Category Entity)
        {
            _categoryDal.Update(Entity);
        }
    }
}
