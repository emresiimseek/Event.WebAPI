using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Abstract
{
    public interface ICommentService:IService<Comment>
    {
         Task<Reply> ReplyComment(Reply Entity);
        public  Task<List<Comment>> GetCommentWithReplies(int Id);


    }
}
