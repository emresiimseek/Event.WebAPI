using Event.Core.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Abstract
{
    public interface IEventDal : IRepository<Activity>
    {
        Task<List<User_Activity>> GetAllFriendsActivities(int id);
        Task<Activity_Like> LikeActivities(Activity_Like Like);
        Task<User_Activity> GetUserActivity(int ActivityId, int UserId);

    }
}
