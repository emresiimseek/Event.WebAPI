using Event.Entities;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Utilities.Mapper
{
    public interface IAutoMapper
    {
        List<TDest> MapToSameList<TSource, TDest>(List<TSource> list) where TSource : new();
        TDest MapToSameType<TSource, TDest>(TSource obg);

    }
}
