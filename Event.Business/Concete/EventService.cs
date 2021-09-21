using Event.Business.Abstract;
using Event.DataAccsess.Abstract;
using Event.Entities;
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

        public IEventDal _eventDal { get; set; }
        public IServiceResponseModel<Event.Entities.Concrete.Event> _serviceResponseModel { get; set; }

        public EventService(IEventDal eventDal, IServiceResponseModel<Event.Entities.Concrete.Event> serviceResponseModel)
        {
            _eventDal = eventDal;
            _serviceResponseModel = serviceResponseModel;
        }

        public async Task<IServiceResponseModel<Entities.Concrete.Event>> AddAsync(Entities.Concrete.Event Entity)
        {
            var result = await _eventDal.AddSync(Entity);
            _serviceResponseModel.Model.Add(result);
            return _serviceResponseModel;
        }

        public void Delete(Entities.Concrete.Event Entity)
        {
            _eventDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _eventDal.DeleteById(EntityId);
        }

        public async Task<IServiceResponseModel<Entities.Concrete.Event>> GetAll(Expression<Func<Event.Entities.Concrete.Event, bool>> filter = null)
        {
            var result = _eventDal.GetAll(filter).ToList();
            _serviceResponseModel.Model = result;

            return _serviceResponseModel;

        }

        public async Task<ServiceResponseModel<Entities.Concrete.Event>> GetAsync(Expression<Func<Entities.Concrete.Event, bool>> filter = null)
        {
            var result = await _eventDal.GetAsync(filter);
            _serviceResponseModel.Model.Add(result);
            return (ServiceResponseModel<Entities.Concrete.Event>)_serviceResponseModel;
        }

        public async Task<IServiceResponseModel<Entities.Concrete.Event>> GetByIdAsync(int id)
        {
            var result = await _eventDal.GetByIdAsync(id);

            _serviceResponseModel.Model.Add(result);

            return _serviceResponseModel;
        }

        public void Update(Entities.Concrete.Event Entity)
        {
            _eventDal.Update(Entity);

        }
    }
}
