using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
