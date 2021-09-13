using Event.Core.Concrete;
using Event.Core.test;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess
{
    public class UserDal : RepositoryBase<User>, IUserDal
    {
        public UserDal(EventContext context, IApplicationUser applicationUser) : base(context, applicationUser)
        {
        }

    }
}
