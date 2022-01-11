using Event.Business.Abstract;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Concete
{
    public class CommentService : ICommentService
    {
        public ICommentDal _commentDal { get; set; }
        public IRepyDal _repyDal { get; set; }

        public CommentService(ICommentDal commentDal, IRepyDal repyDal)
        {
            _commentDal = commentDal;
            _repyDal = repyDal;
        }
        public Task<Comment> AddAsync(Comment Entity)
        {
            return _commentDal.AddSync(Entity);
        }
        public Task<Reply> ReplyComment(Reply Entity)
        {
            return _repyDal.AddSync(Entity);
        }

        public void Delete(Comment Entity)
        {
            _commentDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _commentDal.DeleteById(EntityId);
        }

        public async Task<List<Comment>> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
           return   _commentDal.GetAll(filter,"User").ToList();
        }

        public Task<Comment> GetAsync(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.GetAsync(filter);
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            return _commentDal.GetByIdAsync(id);
        }

        public void Update(Comment Entity)
        {
            _commentDal.Update(Entity);
        }

        public Task<List<Comment>> GetCommentWithReplies(int Id)
        {
            return _commentDal.GetCommentWithsReplies(Id);
        }
    }
}
