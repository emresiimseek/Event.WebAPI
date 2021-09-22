using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class UsersRole : Entity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
