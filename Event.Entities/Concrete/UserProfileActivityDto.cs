using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class UserProfileActivityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public List<CategoryDto> Categories { get; set; }

    }
}
