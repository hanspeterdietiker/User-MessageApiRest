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
        
            _messageService = messageService;
        }

        [HttpGet("searching-message/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var msgFound = await _messageService.FindByIdAsync(id);
            return Ok(msgFound);
        }
        [HttpPost("creating-message")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> CreateMessage(MessageModel message)
        {
            await _messageService.CreateMessageAsync(message);
            return Created("Message Created at Data Base", message);
        }

        [HttpPut("updating-message")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> UpdateMessage(Guid id, [FromBody] MessageModel message)
        {
            await _messageService.UpdateAsync(id, message);
            return Ok(message);
        }
        [HttpDelete("deleting-message/{id}")]
        public IActionResult RemoveMessage(Guid id)
        {
            _messageService.RemoveMessageAsync(id);
            return Ok("Message Deleted");
        }
    }
}
