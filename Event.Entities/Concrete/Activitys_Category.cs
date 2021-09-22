using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Activitys_Category : Entity
    {
        public virtual Activity Activity { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public int ActivityId { get; set; }
    }
}
