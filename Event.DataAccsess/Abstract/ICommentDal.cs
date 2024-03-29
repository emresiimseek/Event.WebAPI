﻿using Event.Core.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.DataAccsess.Abstract
{
    public interface ICommentDal : IRepository<Comment>
    {
        Task<List<Comment>> GetCommentWithsReplies(int id);
    }
}
