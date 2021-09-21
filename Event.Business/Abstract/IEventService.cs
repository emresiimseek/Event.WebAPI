using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Business.Abstract
{
    public interface IEventService : IService<Event.Entities.Concrete.Event>
    {
    }
}
