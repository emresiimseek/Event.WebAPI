using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public virtual List<User_Role> UserRoles { get; set; }
    }
}
