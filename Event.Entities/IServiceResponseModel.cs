using Event.Data.Datas.Abstract;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Entities
{
    public interface IServiceResponseModel<T> 
    {
        List<T> Model { get; set; }
        List<ErrorDto> Errors { get; set; }
    }
}
