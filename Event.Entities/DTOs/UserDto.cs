using Event.Data.Concrete;
using Event.Data.Enums;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EnumGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public  List<UserUserDto> IAmFriendsWith { get; set; }
        public  List<UserUserDto> AreFirendsWithMe { get; set; }
    }
}
