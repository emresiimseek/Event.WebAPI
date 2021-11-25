using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class ActivityLikeDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public int ActivityId { get; set; }
    }
}
