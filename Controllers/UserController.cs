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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }

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