using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface IEventService : IService<Activity>
    {
        Task<List<MainFlowUserActivityDto>> GetAllFriendsActivities(int id);
    }
}
