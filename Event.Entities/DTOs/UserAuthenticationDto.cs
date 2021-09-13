using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Entities.DTOs
{
    public class UserAuthenticationDto
    {
        public string Password { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
