using BackendAPI.Models.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendAPI.Contracts;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public DishContext Context { get; }
        public PostController(DishContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Post> posts = Context.Posts.ToList();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Post? post = Context.Posts.Where(x => x.UserId == id).FirstOrDefault();
            if (post == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(post);
        }



        [HttpPost]
        public IActionResult Add(PostDto post)
        {
            Post newPost = new Post()
            {
                CommentId = post.CommentId,
                UserId = post.UserId,   
                Photo = post.Photo,
                AddedBy = post.AddedBy, 
                DeleteBy = post.DeleteBy,   
                CategoryId = post.CategoryId,   

            };
            Context.Posts.Add(newPost);
            Context.SaveChanges();
            return Ok(post);
        }

        [HttpPut]
        public IActionResult Update(PostDtoUpdate post)
        {
            Post newPost = new Post()
            {
                PostId = post.PostId,
                CommentId = post.CommentId,
                UserId = post.UserId,
                Photo = post.Photo,
                AddedBy = post.AddedBy,
                DeleteBy = post.DeleteBy,
                CategoryId = post.CategoryId,

            };
            Context.Posts.Update(newPost);
            Context.SaveChanges();
            return Ok(newPost);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Post? post = Context.Posts.Where(x => x.PostId == id).FirstOrDefault();
            if (post == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Posts.Remove(post);
            Context.SaveChanges();
            return Ok();
        }
    }
}
