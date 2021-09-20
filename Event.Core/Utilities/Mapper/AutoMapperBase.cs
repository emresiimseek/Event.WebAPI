using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Utilities.Mapper
{
    public class AutoMapperBase : IAutoMapper
    {
        public List<TDest> MapToSameList<TSource, TDest>(List<TSource> list) where TSource : new()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<TSource>, List<TDest>>(list);
            ;
        }

        public TDest MapToSameType<TSource, TDest>(TSource obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDest>(obj);
        }
    }
}
