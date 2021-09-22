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
    public class EventService : IEventService
    {

        private IEventDal _eventDal { get; set; }
        private IServiceResponseModel<Activity> _serviceResponseModel { get; set; }

        public EventService(IEventDal eventDal, IServiceResponseModel<Activity> serviceResponseModel)
        {
            _eventDal = eventDal;
            _serviceResponseModel = serviceResponseModel;
        }

        public async Task<IServiceResponseModel<Activity>> AddAsync(Activity Entity)
        {
            var result = await _eventDal.AddSync(Entity);
            _serviceResponseModel.Model.Add(result);
            return _serviceResponseModel;
        }

        public void Delete(Activity Entity)
        {
            _eventDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _eventDal.DeleteById(EntityId);
        }

        public async Task<IServiceResponseModel<Activity>> GetAll(Expression<Func<Activity, bool>> filter = null)
        {
            var result = _eventDal.GetAll(filter).ToList();
            _serviceResponseModel.Model = result;

            return _serviceResponseModel;

        }

        public async Task<ServiceResponseModel<Activity>> GetAsync(Expression<Func<Activity, bool>> filter = null)
        {
            var result = await _eventDal.GetAsync(filter);
            _serviceResponseModel.Model.Add(result);
            return (ServiceResponseModel<Activity>)_serviceResponseModel;
        }

        public async Task<IServiceResponseModel<Activity>> GetByIdAsync(int id)
        {
            var result = await _eventDal.GetByIdAsync(id);

            _serviceResponseModel.Model.Add(result);

            return _serviceResponseModel;
        }

        public void Update(Activity Entity)
        {
            _eventDal.Update(Entity);

        }
    }
}
