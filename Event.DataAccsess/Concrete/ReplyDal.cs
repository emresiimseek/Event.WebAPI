using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess.Concrete
{
    public class ReplyDal : RepositoryBase<Reply>, IRepyDal
    {

        public ReplyDal(EventContext eventContext, IApplicationUser applicationUser) : base(eventContext, applicationUser)
        {

        }
    }
}
