using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<ServiceResponseModel<User>> Authenticate(string username, string password);
        Task<ServiceResponseModel<User>> AddAsyncWithMessages(User Entity);
        Task<List<Activity>> GetUserWithActivities(int UserId);
        Task<User_User> AddFriend(User_User User);
        void RemoveFriend(User_User User);
        Task<List<User>> SearchUser(string SearchKey);
        Task<User> GetUserWithFriends(int UserId);





    }


}
