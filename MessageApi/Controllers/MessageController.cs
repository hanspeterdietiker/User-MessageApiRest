using MessageAPI.Interfaces;
using MessageAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Controllers
{
        /**
         * updating code with UserService
         * fixing the code
         */
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        [HttpGet("searching-message/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var msgFound = await _messageService.FindById(id);
            return Ok(msgFound);
        }
        [HttpPost("creating-message/{userId}")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreateMessage(Guid userId, [FromBody]MessageModel message)
        {
            await _messageService.CreateMessage(message);
            await _userService.AddMessageToUser(userId, message);

            return Created($"Message created in the database for {userId}", message);
        }

        [HttpPut("updating-message/{id}")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> UpdateMessage(Guid userId, Guid id, [FromBody] MessageModel message)
        {
            await _messageService.Update(id, message);
            return Ok(message);
        }
        [HttpDelete("deleting-message/{id}")]
        public IActionResult RemoveMessage(Guid id, Guid userId, [FromBody]MessageModel message)
        {
            _messageService.RemoveMessage(id);
            _userService.RemoveMessageToUser(userId, message);

            return Ok($"Message Deleted in the database for {userId}");
        }
    }
}
