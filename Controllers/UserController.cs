
using System.Linq;
using LibraryManager.Api.Model;
using LibraryManager.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryManagerDb _context;

        public UserController(LibraryManagerDb context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetUser()
        {
            var resultUser = _context.Users.ToList();
            return Ok(resultUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var userId = _context.Users.SingleOrDefault(i => i.Id == id);
            return Ok(userId);
        }

        [HttpPost]
        public IActionResult Post(CreateUserModel modelUser)
        {
            if (string.IsNullOrWhiteSpace(modelUser.Name))
            {
                return BadRequest("O nome é obrigatorio e não pode ser em branco.");
            }

            if (string.IsNullOrWhiteSpace(modelUser.Email))
            {
                return BadRequest("O email é obrigatorio e não pode ser em branco.");
            }

            var user = modelUser.FromEntity();
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new {id = user.Id}, modelUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_context.Users.Any(i => i.Id == id))
            {
                return BadRequest("O Id informado não foi encontrado");
            }
            return NoContent();
        }



    }
}
