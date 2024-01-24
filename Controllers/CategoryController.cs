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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = Context.Categories.ToList();
            return Ok(categories);
        }

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
