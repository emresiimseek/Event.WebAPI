using Event.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EnumGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
