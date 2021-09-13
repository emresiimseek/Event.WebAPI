using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.Concrete
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }

    }
}
