using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class UserUserDto
    {
        public int UserChildId { get; set; }
        public int UserParentId { get; set; }

        public  UserDto UserChild { get; set; }
        public  UserDto UserParent { get; set; }
    }
}
