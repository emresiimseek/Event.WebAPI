using Event.Core.Utilities.Mapper;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Business.Mappers
{
    public class ActivityMapper : AutoMapperBase
    {
        public List<MainFlowUserActivityDto> MapFirendsActivities(List<User_Activity> values)
        {

            return MapList<User_Activity, MainFlowUserActivityDto>(values, cfg =>
              {
                  cfg.CreateMap<Activity_Category, CategoryDto>()
                  .ForMember(c => c.Title, z => z.MapFrom(c => c.Category.Title))
                  .ForMember(c => c.Id, z => z.MapFrom(c => c.CategoryId));

                  cfg.CreateMap<User_Activity, MainFlowUserActivityDto>()
                 .ForMember(c => c.ActivityDate, b => b.MapFrom(z => z.Activity.EventDate))
                 .ForMember(c => c.ActivityDescription, c => c.MapFrom(s => s.Activity.Description))
                 .ForMember(c => c.UserId, c => c.MapFrom(s => s.User.Id))
                 .ForMember(c => c.UserName, c => c.MapFrom(s => s.User.UserName))
                 .ForMember(c => c.UserFullName, c => c.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"))
                 .ForMember(c => c.ActivityTitle, c => c.MapFrom(s => s.Activity.Title))
                 .ForMember(c => c.Categories, c => c.MapFrom(s => s.Activity.ActivityCategories));
              });
        }
    }
}
