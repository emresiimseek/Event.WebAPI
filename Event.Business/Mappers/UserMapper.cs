using Event.Core.Utilities.Mapper;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Business.Mappers
{
    public class UserMapper : AutoMapperBase
    {
        public List<MainFlowUserActivityDto> MapUserActivity(List<Activity> values)
        {
            return MapList<Activity, MainFlowUserActivityDto>(values, cfg =>
              {
                  cfg.CreateMap<Activity_Category, CategoryDto>()
                  .ForMember(c => c.Id, b => b.MapFrom(z => z.CategoryId))
                  .ForMember(c => c.Title, c => c.MapFrom(s => s.Category.Title));

                  cfg.CreateMap<Activity, MainFlowUserActivityDto>()
                  .ForMember(a => a.ActivityTitle, b => b.MapFrom(c => c.Title))
                  .ForMember(a => a.ActivityDescription, b => b.MapFrom(c => c.Description))
                  .ForMember(a => a.ActivityDate, b => b.MapFrom(c => c.EventDate))
                  .ForMember(a => a.Categories, b => b.MapFrom(c => c.ActivityCategories))
                  .ForMember(a => a.UserId, b => b.MapFrom(c => c.UserActivities.FirstOrDefault().User.Id))
                  .ForMember(a => a.UserName, b => b.MapFrom(c => c.UserActivities.FirstOrDefault().User.UserName))
                  .ForMember(a => a.UserFullName,
                  b => b.MapFrom(c =>
                  c.UserActivities.FirstOrDefault().User.FirstName +
                  c.UserActivities.FirstOrDefault().User.LastName));
              });
        }

        public UserDto MapUser(User user)
        {
            return Map<User, UserDto>(user, cfg =>
            {
                cfg.CreateMap<User_User, UserUserDto>()
                .ForMember(u => u.UserChild, b => b.MapFrom(z => z.UserChild))
                .ForMember(u => u.UserParent, b => b.MapFrom(z => z.UserParent));



                cfg.CreateMap<User, UserDto>()
               .ForMember(u => u.AreFirendsWithMe, b => b.MapFrom(z => z.AreFirendsWithMe))
               .ForMember(u => u.IAmFriendsWith, b => b.MapFrom(z => z.IAmFriendsWith));

            });
        }
    }
}
