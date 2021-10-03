﻿using Event.Business.Abstract;
using Event.Business.Mappers;
using Event.DataAccsess.Abstract;
using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
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
        private ActivityMapper _activityMapper { get; set; }

        public EventService(IEventDal eventDal, IServiceResponseModel<Activity> serviceResponseModel, ActivityMapper activityMapper)
        {
            _eventDal = eventDal;
            _serviceResponseModel = serviceResponseModel;
            _activityMapper = activityMapper;
        }

        public async Task<Activity> AddAsync(Activity Entity)
        {
            return await _eventDal.AddSync(Entity);
        }

        public void Delete(Activity Entity)
        {
            _eventDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _eventDal.DeleteById(EntityId);
        }

        public async Task<List<Activity>> GetAll(Expression<Func<Activity, bool>> filter)
        {
            return _eventDal.GetAll(filter).ToList();
        }

        public async Task<Activity> GetAsync(Expression<Func<Activity, bool>> filter = null)
        {
            return await _eventDal.GetAsync(filter);
        }
        public async Task<Activity> GetByIdAsync(int id)
        {
            return await _eventDal.GetByIdAsync(id);

        }

        public void Update(Activity Entity)
        {
            _eventDal.Update(Entity);

        }

        public async Task<List<MainFlowUserActivityDto>> GetAllFriendsActivities(int id)
        {
            var values = await _eventDal.GetAllFriendsActivities(id);

            return _activityMapper.MapFirendsActivities(values);



        }
    }
}
