using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class User_User:Entity
    {
        public int UserChildId { get; set; }
        public int UserParentId { get; set; }

        public virtual User UserChild { get; set; }
        public virtual User UserParent { get; set; }

        public bool Approved { get; set; }
    }
}
