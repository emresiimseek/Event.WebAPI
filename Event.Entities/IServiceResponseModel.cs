using Event.Entities.Abstract;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Entities
{
    public interface IServiceResponseModel<T> where T : class, IEntity, new()
    {
        List<T> Model { get; set; }
        List<ErrorDto> Errors { get; set; }
    }
}
