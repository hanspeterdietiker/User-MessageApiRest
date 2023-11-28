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
            var user = await _userService.FindByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            await _userService.CreateUserAsync(user);
            return Created("Usuario cadastrado no Banco de Dados", user);
        }
    }
}
