using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess
{
    public class UserDal : RepositoryBase<User>, IUserDal
    {
        public EventContext _eventContext { get; set; }
        public UserDal(EventContext context, IApplicationUser applicationUser, EventContext eventContext) : base(context, applicationUser)
        {
            _eventContext = eventContext;

        }
        public async Task<List<Activity>> GetUserWithActivities(int UserId)
        {
            var result = _eventContext.Users.Include(u => u.UserActivities).ThenInclude(a => a.Activity).ThenInclude(b => b.ActivityCategories).ThenInclude(c => c.Category).FirstOrDefault(u => u.Id == UserId);

            var test = _eventContext.Users.Include(s => s.IAmFriendsWith).ToList();

            return result.UserActivities.Select(ua => ua.Activity).ToList();
        }

        public async Task<List<User>> SearchUser(string SearchKey)
        {
            return _eventContext.Users.Where(u => u.FirstName.Contains(SearchKey) || u.LastName.Contains(SearchKey)).ToList();
        }

        public async Task<User> GetUserWithFriends(int UserId)
        {
            return _eventContext.Users
                .Include(u => u.IAmFriendsWith)
                .ThenInclude(uu => uu.UserChild)
                .Include(u => u.AreFirendsWithMe)
                .ThenInclude(uu => uu.UserParent)
                .FirstOrDefault(u => u.Id == UserId);
        }


    }
}
