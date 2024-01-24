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
        /// <summary>
        /// Вывод всех записей о комментариях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Комментарии</param>
        /// <returns></returns>
        /// 
        // GET api/<CommentController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> comments = Context.Comments.ToList();
            return Ok(comments);
        }
   
        /// <summary>
        /// Поиск комментария по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id комментария"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о комментариях</param>
        /// <returns></returns>
        // GET api/<CommentController>
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




        /// <summary>
        /// Создание нового комментария
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Content" : "Введите комментарий"
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового комментария</param>
        /// <returns></returns>
        // GET api/<CommentController>
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
        /// <summary>
        /// Обновление существующего комментария
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "CommentId" : "Ввести id комментария, информацию о котором нужно изменить"
        ///             "Content" : "Изменяемый контент комментария "
        ///         }
        /// </remarks>
        /// <param name="model">Обновление существующего комментария</param>
        /// <returns></returns>
        // PUT api/CommentController>
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

        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id комментария, который нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление комментария</param>
        /// <returns></returns>
        // DELETE api/<CommentController>
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

