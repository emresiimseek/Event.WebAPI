using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
