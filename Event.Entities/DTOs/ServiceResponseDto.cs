using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class ServiceResponseDto<Dto> : IServiceResponseDto<Dto> 
    {
        public ServiceResponseDto()
        {
            Errors = new List<ErrorDto>();
            Model = new List<Dto>();
        }
        public List<Dto> Model { get; set; }
        public List<ErrorDto> Errors { get; set; }
    }
}
