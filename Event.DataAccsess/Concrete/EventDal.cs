using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess.Concrete
{
    public class EventDal : RepositoryBase<Event.Entities.Concrete.Event>, IEventDal
    {
        public EventDal(EventContext context, IApplicationUser applicationUser) : base(context, applicationUser)
        {
        }

    }
}
