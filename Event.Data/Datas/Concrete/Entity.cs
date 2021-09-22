using Event.Data.Concrete;
using Event.Data.Datas.Abstract;
using Event.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Data.Datas.Concrete
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public EnumState State { get; set; }
    }
}
