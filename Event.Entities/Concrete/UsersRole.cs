using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class UsersRole:Entity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
