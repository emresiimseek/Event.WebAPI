using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess.Concrete
{
    public class CommentDal : RepositoryBase<Comment>, ICommentDal
    {
        public CommentDal(EventContext eventContext, IApplicationUser applicationUser) : base(eventContext, applicationUser)
        {

        }
    }
}
