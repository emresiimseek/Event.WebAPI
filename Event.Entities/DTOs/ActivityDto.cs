using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class ActivityDto: IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public List<User_Activity> ActivitysEvents { get; set; }
        public List<Activitys_Category> ActivitysCategory { get; set; }

    }
}
