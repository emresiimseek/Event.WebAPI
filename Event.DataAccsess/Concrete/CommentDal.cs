using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Concrete
{
    public class CommentDal : RepositoryBase<Comment>, ICommentDal
    {
        public EventContext _eventContext { get; set; }

        public CommentDal(EventContext eventContext, IApplicationUser applicationUser) : base(eventContext, applicationUser)
        {
            _eventContext = eventContext;

        }

        public async Task<List<Comment>> GetCommentWithsReplies(int id)
        {
            return _eventContext.Comments.Where(x => x.ActivityId == id).Include(c => c.ReplyComments).Include(x => x.User).ToList();
        }
    }
}
