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
        public async Task<List<User_Activity>> GetUserWithActivities(int UserId)
        {
            return _eventContext.UserActivities.Include(u => u.User).Include(u => u.Activity).Where(u => u.UserId == UserId).ToList();
        }

    }
}
