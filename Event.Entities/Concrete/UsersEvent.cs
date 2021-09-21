using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class UsersEvent
    {
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

    }
}
