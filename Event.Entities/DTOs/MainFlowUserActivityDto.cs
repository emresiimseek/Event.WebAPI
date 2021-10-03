using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class MainFlowUserActivityDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityTitle { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public DateTime ActivityDate { get; set; }

    }
}
