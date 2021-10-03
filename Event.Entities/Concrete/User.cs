using Event.Data.Datas.Concrete;
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
        public string Email { get; set; }
        public bool PrivateAccount { get; set; }
        public List<User_Activity> UserActivities { get; set; }
        public List<User_Role> UserRoles { get; set; }
        public List<Comment> Comments { get; set; }

        public virtual List<User_User> IAmFriendsWith { get; set; }
        public virtual List<User_User> AreFirendsWithMe { get; set; }

    }
}
