using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using TLTask.Data;
using TLTask.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TLTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        public readonly ApplicationDbContext Context;

        public UserController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        //---------------------- Get All ---------------------------

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await Context.Users.ToListAsync());
        }

        //-------------------- Post or Create -----------------------


        public class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter()
        {
            DateTimeFormat = "MM-dd-yyyy";
        }
    }

    [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest request)
        {
           
            var User = new User()
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                UserName = request.UserName,
                Password = request.Password,
                CreationDate = request.CreationDate
            };

            await Context.Users.AddAsync(User);
            await Context.SaveChangesAsync();
            return Ok(User);
        }

        //----------------------- Get One Data ---------------------------

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        // ---------------------------------Update-------------------------------
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequst UpdateUser)
        {
            var User = await Context.Users.FindAsync(id);
            if (User != null)
            {
               User.FullName = UpdateUser.FullName;
                User.LastName = UpdateUser.LastName;
                User.Email = UpdateUser.Email;
                User.Phone = UpdateUser.Phone;
                User.UserName = UpdateUser.UserName;
                User.Password = UpdateUser.Password;

                await Context.SaveChangesAsync();
                return Ok(User);
            }
            return BadRequest();
        }


        //-------------------------------Remove------------------------------
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var Employee = await Context.Users.FindAsync(id);

            if (Employee != null)
            {
                Context.Remove(Employee);
                await Context.SaveChangesAsync();
                return Ok(Employee);
            }
            return BadRequest();
        }
    }
}
