using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Event : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<UsersEvent> UsersEvents { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
