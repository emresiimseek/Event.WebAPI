using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class UserActivityDto
    {

        public UserDto UserDto { get; set; }
        public ActivityDto ActivityDto { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
    }
}
