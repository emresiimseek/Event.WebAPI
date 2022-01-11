using Event.Business.Abstract;
using Event.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        public ICommentService _commentService { get; set; }
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetByActivity/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = _commentService.GetCommentWithReplies(id);
            return Ok(values.Result);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Comment comment)
        {
            return Created(String.Empty, _commentService.AddAsync(comment));
        }

        [HttpPost("ReplyComment")]
        public async Task<IActionResult> ReplyComment(Reply reply)
        {
           return Created(String.Empty,_commentService.ReplyComment(reply)) ;

        }


    }
}
