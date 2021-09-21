using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Category : Entity
    {
        public string Title { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }

    }
}
