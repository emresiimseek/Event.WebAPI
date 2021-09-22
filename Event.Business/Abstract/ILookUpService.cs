using Event.Data.Concrete;
using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface ILookUpService<T> where T : Entity, new()
    {
        public IService<T> _service { get; set; }

        Task<List<LookUp>> GetLookUp(Expression<Func<T, bool>> expression, string propKey = "", string propsValue = "");
    }
}
