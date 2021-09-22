using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class User_Activity
    {
        public virtual User User { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }

    }
}
