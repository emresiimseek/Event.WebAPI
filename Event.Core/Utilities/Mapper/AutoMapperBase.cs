using AutoMapper;
using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Utilities.Mapper
{
    public class AutoMapperBase : IAutoMapper
    {
        public TDest Map<TSource, TDest>(TSource values, Action<IMapperConfigurationExpression> configure)
        {
            var config = new MapperConfiguration(configure);
            var mapper = config.CreateMapper();
            return mapper.Map<TSource, TDest>(values);

        }

        public List<TDest> MapList<TSource, TDest>(List<TSource> values, Action<IMapperConfigurationExpression> configure)
        {
            var config = new MapperConfiguration(configure);
            var mapper = config.CreateMapper();
            return mapper.Map<List<TSource>, List<TDest>>(values);
        }

        public List<TDest> MapToSameList<TSource, TDest>(List<TSource> list) where TSource : new()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>().ReverseMap());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<TSource>, List<TDest>>(list);
            ;
        }

        public TDest MapToSameType<TSource, TDest>(TSource obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>().ReverseMap());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDest>(obj);
        }
    }
}
