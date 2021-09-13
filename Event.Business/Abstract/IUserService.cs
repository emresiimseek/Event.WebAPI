using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}
