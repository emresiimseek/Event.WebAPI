using Event.Business.Abstract;
using Event.Data.Concrete;
using Event.Data.Datas.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Concete
{
    public class LookUpService<T> : ILookUpService<T> where T : Entity, new()
    {
        public IService<T> _service { get; set; }

        public LookUpService(IService<T> service)
        {
            _service = service;
        }



        public async Task<List<LookUp>> GetLookUp(Expression<Func<T, bool>> expression = null, string propKey = "", string propsValue = "")
        {
            var result = await _service.GetAll(expression);
            var keyField = typeof(T).GetProperty(propKey);
            var valueField = typeof(T).GetProperty(propsValue);

            var data = result.Select(item =>
            {
                string key = keyField.GetValue(item).ToString();
                string value = valueField.GetValue(item).ToString();

                return new LookUp { Key = Convert.ToInt32(key), Value = value };
            });

            return data.ToList();

        }


    }
}
