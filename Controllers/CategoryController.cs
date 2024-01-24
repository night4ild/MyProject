using BackendAPI.Models.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public DishContext Context { get; }
        public CategoryController(DishContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Вывод всех записей о категориях
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        /// </remarks>
        /// <param name="model">Категории</param>
        /// <returns></returns>
        /// 
        // GET api/<CategoryController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = Context.Categories.ToList();
            return Ok(categories);
        }
        /// <summary>
        /// Поиск категории по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "CategoryId" : "id категории"
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о категориях</param>
        /// <returns></returns>
        // GET api/<CategotyController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Category? category = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(category);
        }

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "CategoryName" : "Введите название новой категории"
        ///         }
        /// </remarks>
        /// <param name="model">Создание новой категории</param>
        /// <returns></returns>
        // GET api/<CategoryController>
        [HttpPost]
        public IActionResult Add(CategoryDto category)
        {
            Category newCategory = new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Post = category.Post,
            };

            Context.Categories.Add(newCategory);
            Context.SaveChanges();
            return Ok(category);
        }
        /// <summary>
        /// Обновление существующей категории
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "CategoryId" : "Ввести id категории, информацию о котой нужно изменить"
        ///             "CategoryName" : "Название категории, которую меняете "
        ///         }
        /// </remarks>
        /// <param name="model">Обновление существующеЙ категории</param>
        /// <returns></returns>
        // PUT api/CategoryController>
        [HttpPut]
        public IActionResult Update(CategoryDtoUpdate category)
        {
            Category newCategory = new Category()
            {

                CategoryName = category.CategoryName,
                Post = category.Post,

            };
            Context.Categories.Update(newCategory);
            Context.SaveChanges();
            return Ok(newCategory);
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id категории пользователя,  которую нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление категории</param>
        /// <returns></returns>
        // DELETE api/<CategoryController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Category? category = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Categories.Remove(category);
            Context.SaveChanges();
            return Ok();
        }
    }
}
