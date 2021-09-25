using Event.Core.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        Task<List<User_Activity>> GetUserWithActivities(int UserId);
    }
}
