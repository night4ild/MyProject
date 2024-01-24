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
        /// <summary>
        /// Вывод всех записей о постах
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Посты</param>
        /// <returns></returns>
        /// 
        // GET api/<PostController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Post> posts = Context.Posts.ToList();
            return Ok(posts);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id поста"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о постах</param>
        /// <returns></returns>
        // GET api/<PostController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Post? post = Context.Posts.Where(x => x.PostId == id).FirstOrDefault();
            if (post == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(post);
        }


        /// <summary>
        /// Создание новой модели машины
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "UserId" : "Введите id пользователя (49375)"
        ///             "Photo" : "Прикрепите фото к посту (77742348.jpg)"
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового поста</param>
        /// <returns></returns>
        // GET api/<PostController>
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
        /// <summary>
        /// Обновление существующего поста
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///          "UserId" : "Введите id пользователя которого нужно изменить (49375)"
        ///             "Photo" : "Прикрепите фото к посту (77742348.jpg)"
        ///         }
        /// </remarks>
        /// <param name="model">Обновление существующего поста</param>
        /// <returns></returns>
        // GET api/<PostController>
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

        /// <summary>
        /// Удаление поста
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id поста, который нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление поста</param>
        /// <returns></returns>
        // GET api/<PostController>

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
