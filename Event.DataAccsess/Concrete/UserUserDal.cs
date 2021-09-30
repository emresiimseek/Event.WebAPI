using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Concrete
{
    public class UserUserDal : RepositoryBase<User_User>, IUserUserDal
    {
        public UserUserDal(EventContext context, IApplicationUser applicationUser) : base(context, applicationUser)
        {

        }
      
    }
}
