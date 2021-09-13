using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public virtual List<UsersRole> UsersRoles { get; set; }
    }
}
