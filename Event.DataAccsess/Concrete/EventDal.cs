using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Concrete
{
    public class EventDal : RepositoryBase<Activity>, IEventDal
    {
        public EventContext _eventContext { get; set; }
        public EventDal(EventContext context, IApplicationUser applicationUser, EventContext eventContext) : base(context, applicationUser)
        {
            _eventContext = eventContext;

        }

        public async Task<List<User_Activity>> GetAllFriendsActivities(int id)
        {
            var list = new List<User_Activity>();

            var data = _eventContext.Users
              .Include(u => u.UserActivities)
              .ThenInclude(b => b.Activity)
              .ThenInclude(x => x.ActivityLikes)
              .Include(b => b.UserActivities)
              .ThenInclude(x => x.Activity)
              .ThenInclude(x => x.ActivityCategories)
              .ThenInclude(a => a.Category)
              .Include(u => u.IAmFriendsWith)
              .ThenInclude(uu => uu.UserChild)
              .ThenInclude(a => a.UserActivities)
              .ThenInclude(x => x.Activity)
              .ThenInclude(a => a.ActivityCategories).ThenInclude(a => a.Category)
              .FirstOrDefault(u => u.Id == id);

            var mine = data.UserActivities;
            

            list.AddRange(mine);


            if (data.PrivateAccount)
                list.AddRange(data.IAmFriendsWith.Where(u => u.Approved).SelectMany(x => x.UserChild.UserActivities.Select(x => x)).ToList());
            else list.AddRange(data.IAmFriendsWith.SelectMany(x => x.UserChild.UserActivities.Select(x => x)).ToList());

            return  list.OrderBy(x => x.Activity.EventDate).ToList();

        }

        public async Task<Activity_Like> LikeActivities(Activity_Like Like)
        {
            EntityEntry result = await _eventContext.ActivityLikes.AddAsync(Like);
            await _dbContext.SaveChangesAsync();
            return (Activity_Like)result.Entity;

        }
        public async Task<User_Activity> GetUserActivity(int ActivityId,int UserId)
        {
            var data = _eventContext.Users
              .Include(u => u.UserActivities)
              .ThenInclude(b => b.Activity)
              .ThenInclude(x => x.ActivityLikes)
              .Include(b => b.UserActivities)
              .ThenInclude(x => x.Activity)
              .ThenInclude(x => x.ActivityCategories)
              .ThenInclude(a => a.Category)
              .Include(u => u.IAmFriendsWith)
              .ThenInclude(uu => uu.UserChild)
              .ThenInclude(a => a.UserActivities)
              .ThenInclude(x => x.Activity)
              .ThenInclude(a => a.ActivityCategories).ThenInclude(a => a.Category)
              .FirstOrDefault(u => u.Id == UserId).UserActivities.FirstOrDefault(x=>x.ActivityId==ActivityId);

            return data;

        }
    }
}
