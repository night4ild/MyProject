using BackendAPI.Models;
using BackendAPI.Models.Contracts;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public DishContext Context { get; }
        public UsersController(DishContext context)
        {
            Context = context;
        }
        /// <summary>
        ///  Вывод всех записей о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "login" : "A4Tech Bloody B188",
        ///        "passkey" : "!Pa$$word123@",
        ///        "firstname" : "Иван",
        ///        "lastname" : "Иванов"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // GET api/<UserController>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }
        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "id" : "id пользователя
        ///         }
        /// </remarks>
        /// <param name="model">Получение информации о пользователях</param>
        /// <returns></returns>
        // GET api/<UserController>
        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(user);
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "UserName" : "Введите логин нового пользователя"
        ///             "Email" : "Введите почту нового пользователя"
        ///             "Passkey" : "Введите пароль нового пользователя"
        ///             "City" : "Введите местоположении нового пользователя"
        ///             "RoleId" : "Введите роль нового пользователя"
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового пользователя</param>
        /// <returns></returns>
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Add(UserDto user)
        {
            User newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Mobile = user.Mobile,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Passkey = user.Passkey,
                City = user.City,
                RoleId = user.RoleId,

            };
            Context.Users.Add(newUser);
            Context.SaveChanges();
            return Ok(user);
        }
        /// <summary>
        ///  Изменение нового пользователя
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "UserID" : "id пользователя, в котором нужно изменить данные"
        ///             "UserName" : "Введите логин нового пользователя"
        ///             "Email" : "Введите почту нового пользователя"
        ///             "Password" : "Введите пароль нового пользователя"
        ///             "Location" : "Введите местоположении нового пользователя"
        ///             "RoleId" : "Введите роль нового пользователя"
        ///         }
        /// </remarks>
        /// <param name="model">Создание нового пользователя</param>
        /// <returns></returns>
        // PUT api/<UserController>
        [HttpPut]
        public IActionResult Update(UserDtoUpdate user)
        {
            User newUser = new User()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Mobile = user.Mobile,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Passkey = user.Passkey,
                City = user.City,
                RoleId = user.RoleId,

            };
            Context.Users.Update(newUser);
            Context.SaveChanges();
            return Ok(newUser);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks>
        ///  Пример запроса:
        ///  
        ///         {
        ///             "Ввести id пользователя,  которого нужно удалить"
        ///         }
        /// </remarks>
        /// <param name="model">Удаление пользователя</param>
        /// <returns></returns>
        // DELETE api/<UserController>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}