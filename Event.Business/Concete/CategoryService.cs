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


        public async Task<IServiceResponseModel<Category>> AddAsync(Category Entity)
        {
            var result = await _categoryDal.AddSync(Entity);
            _serviceResponseModel.Model.Add(result);
            return _serviceResponseModel;
        }

        public void Delete(Category Entity)
        {
            _categoryDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _categoryDal.DeleteById(EntityId);
        }

        public async Task<IServiceResponseModel<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var result = _categoryDal.GetAll(filter).ToList();
            _serviceResponseModel.Model = result;

            return _serviceResponseModel;
        }

        public async Task<ServiceResponseModel<Category>> GetAsync(Expression<Func<Category, bool>> filter = null)
        {
            var result = await _categoryDal.GetAsync(filter);
            _serviceResponseModel.Model.Add(result);
            return (ServiceResponseModel<Category>)_serviceResponseModel;
        }

        public async Task<IServiceResponseModel<Category>> GetByIdAsync(int id)
        {
            var result = await _categoryDal.GetByIdAsync(id);

            _serviceResponseModel.Model.Add(result);

            return _serviceResponseModel;
        }

        public void Update(Category Entity)
        {
            _categoryDal.Update(Entity);
        }
    }
}
