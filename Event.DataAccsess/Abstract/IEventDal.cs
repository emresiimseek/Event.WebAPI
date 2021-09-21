using Event.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess.Abstract
{
    public interface IEventDal : IRepository<Event.Entities.Concrete.Event>
    {
    }
}
