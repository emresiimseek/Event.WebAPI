﻿using Event.Entities.Abstract;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Entities
{
    public class ServiceResponseModel<T> : IServiceResponseModel<T> where T : class, IEntity, new()
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
