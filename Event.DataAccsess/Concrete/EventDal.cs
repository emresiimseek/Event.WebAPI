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

namespace Event.DataAccsess.Concrete
{
    public class EventDal : RepositoryBase<Activity>, IEventDal
    {
        public EventContext EventContext { get => _dbContext as EventContext; }
        public EventDal(EventContext context, IApplicationUser applicationUser) : base(context, applicationUser)
        {
        }
        
    }
}
