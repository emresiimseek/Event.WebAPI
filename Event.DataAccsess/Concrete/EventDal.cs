using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var data = _eventContext.Users
              .Include(u => u.IAmFriendsWith)
              .ThenInclude(uu => uu.UserChild)
              .ThenInclude(a => a.UserActivities)
              .ThenInclude(x => x.Activity)
              .ThenInclude(a => a.ActivityCategories).ThenInclude(a => a.Category)
              .FirstOrDefault(u => u.Id == id);

            if (data.PrivateAccount)
                return data.IAmFriendsWith.Where(u => u.Approved).SelectMany(x => x.UserChild.UserActivities.Select(x => x)).ToList();
            else return data.IAmFriendsWith.SelectMany(x => x.UserChild.UserActivities.Select(x => x)).ToList();

        }
    }
}
