using Event.Core.Utilities.Mapper;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Business.Mappers
{
    public class UserMapper : AutoMapperBase
    {
        public List<UserProfileActivityDto> MapUserActivity(List<Activity> values)
        {
            return MapList<Activity, UserProfileActivityDto>(values, cfg =>
              {
                  cfg.CreateMap<Activity_Category, CategoryDto>()
                  .ForMember(c => c.Id, b => b.MapFrom(z => z.CategoryId))
                  .ForMember(c => c.Title, c => c.MapFrom(s => s.Category.Title));

                  cfg.CreateMap<Activity, UserProfileActivityDto>()
                  .ForMember(a => a.Title, b => b.MapFrom(c => c.Title))
                  .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                  .ForMember(a => a.EventDate, b => b.MapFrom(c => c.EventDate))
                  .ForMember(a => a.Categories, b => b.MapFrom(c => c.ActivityCategories));
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
