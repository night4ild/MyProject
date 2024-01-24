using BackendAPI.Models.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public DishContext Context { get; }
        public CommentController(DishContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> comments = Context.Comments.ToList();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Comment? comment = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (comment == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(comment);
        }



        [HttpPost]
        public IActionResult Add(CommentDto comment)
        {
            Comment newComment = new Comment()
            {
               PostId = comment.PostId,
               UserId = comment.UserId,
               Content = comment.Content,
               AddedBy = comment.AddedBy,
               DeleteBy = comment.DeleteBy,
            };

            Context.Comments.Add(newComment);
            Context.SaveChanges();
            return Ok(comment);
        }

        [HttpPut]
        public IActionResult Update(CommentDtoUpdate comment)
        {
            Comment newComment = new Comment()
            {
                CommentId = comment.CommentId,
                PostId = comment.PostId,
                UserId = comment.UserId,
                Content = comment.Content,
                AddedBy = comment.AddedBy,
                DeleteBy = comment.DeleteBy,
            };

            Context.Comments.Update(newComment);
            Context.SaveChanges();
            return Ok(newComment);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Comment? comment = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (comment == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Comments.Remove(comment);
            Context.SaveChanges();
            return Ok();
        }
    }
}

