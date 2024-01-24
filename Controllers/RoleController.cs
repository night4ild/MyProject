using BackendAPI.Models.Contracts;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BackendAPI.Contracts;
using System.Data;

namespace BackendAPI.Controllers
{
    public class RoleController : Controller
    {
        public DishContext Context { get; }
        public RoleController(DishContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetByld(int id)
        {
            Role? role = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Данные не найдены");
            }
            return Ok(role);
        }



        [HttpPost]
        public IActionResult Add(RoleDto role)
        {
            Role newRole = new Role()
            {
                RoleName = role.RoleName

            };
            Context.Roles.Add(newRole);
            Context.SaveChanges();
            return Ok(role);
        }

        [HttpPut]
        public IActionResult Update(RoleDtoUpdate role)
        {
            Role newRole = new Role()
            {
                RoleId = role.RoleId,   
                RoleName = role.RoleName
            };
            Context.Roles.Update(newRole);
            Context.SaveChanges();
            return Ok(newRole);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Role? role = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Данные не найдены");
            }

            Context.Roles.Remove(role);
            Context.SaveChanges();
            return Ok();
        }
    }
}
