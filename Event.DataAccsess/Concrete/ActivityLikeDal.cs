using Event.Core.Abstract;
using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Concrete
{
    public class ActivityLikeDal : RepositoryBase<Activity_Like>, IActivityLikeDal
    {

        public EventContext _eventContext { get; set; }
        public ActivityLikeDal(EventContext context, IApplicationUser applicationUser, EventContext eventContext) : base(context, applicationUser)
        {
            _eventContext = eventContext;

        }


    }
}
