using Event.Data.Datas.Abstract;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Entities
{
    public class ServiceResponseModel<T> : IServiceResponseModel<T>
    {

        public ServiceResponseModel()
        {
            Errors = new List<ErrorDto>();
            Model = new List<T>();
        }
        public List<T> Model { get; set; }
        public List<ErrorDto> Errors { get; set; }
    }
}
