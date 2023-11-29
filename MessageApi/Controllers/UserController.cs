using MessageAPI.Entities;
using MessageAPI.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("ERROR:Invalide Id");
            }
            var user = await _userService.FindByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreateUser(UserModel? user)
        {
            await _userService.CreateUserAsync(user);
            return Created("User registered in the Database", user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(Guid? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("ERROR:Invalide Id");
            }
            await _userService.RemoveAsync(id);

            return NoContent();

        }
    }
}
