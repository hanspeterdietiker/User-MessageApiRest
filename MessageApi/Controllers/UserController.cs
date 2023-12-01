using MessageAPI.Entities;
using MessageAPI.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("searching-user/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.FindByIdAsync(id);
            return Ok(user);
        }

        [HttpPost("creating-user")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            await _userService.CreateUserAsync(user);
            return Created("User registered in the Database", user);
        }

        [HttpPut("updating-user/{id}")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            await _userService.UpdateAsync(user);
            return Ok(user);
        }

        [HttpDelete("deleting-user/{id}")]
        public IActionResult RemoveUser(Guid id)
        {
            _userService.RemoveUser(id);
            return Ok("User Deleted");

        }
    }
}
