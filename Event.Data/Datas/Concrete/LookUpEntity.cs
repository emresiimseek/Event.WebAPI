using Event.Data.Datas.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Data.Datas.Concrete
{
    public class LookUpEntity<T> where T : class, ILookUp, new()
    {
        public String Type { get; set; }
        public String Name { get; set; }
    }
}
