using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Activity : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public List<User_Activity> UserActivities { get; set; }
        public List<Activity_Category> ActivityCategories { get; set; }
        public List<Activity_Like> ActivityLikes { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
