using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Category : Entity
    {
        public string Title { get; set; }
        public List<Activity_Category> ActivityCategories { get; set; }

    }
}
