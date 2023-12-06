using MessageAPI.Dto;
using MessageAPI.Interfaces;
using MessageAPI.Models;
using MessageAPI.Persistence;
using MessageAPI.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MessageAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageApiContext _context;

        public MessageService(MessageApiContext context)
        {
            _context = context;
        }

        public async Task CreateMessageAsync(MessageModel msg)
        {
            _context.Add(msg);
            await _context.SaveChangesAsync();
        }

        public async Task<MessageDto> FindByIdAsync(Guid id)
        {
            {
                bool msgFound = _context.MessageModel
                    .AnyAsync(a => a.Id == id);

                if (!msgFound)
                {
                    throw new EntityNotFoundException("Message not found with the provided ID");
                }
                var msg = await _context.MessageModel.FindAsync(id);

                var MessageDto = new MessageDto
                {
                    Id = msg.Id,
                    Status = msg.Status,
                    SentWent = msg.SentWent,
                    Text = msg.Text
                };
                return MessageDto;

            }

        }
        public async Task<MessageDto> UpdateAsync(Guid id, MessageModel msg)
        {
            var msgFound = await _context.MessageModel.FindAsync(id);
            if (msgFound == null)
            {
                throw new EntityNotFoundException("Entity Not Found With Id");
            }

            msgFound.Text = msg.Text;
            msgFound.SentWent = msg.SentWent;

            var MessageDto = new MessageDto
            {
                Id = msg.Id,
                Status = msg.Status,
                SentWent = msg.SentWent,
                Text = msg.Text
            };

            await _context.SaveChangesAsync();
            return MessageDto;
        }

        public void RemoveMessageAsync(Guid id)
        {
            var msgToRemove = _context.MessageModel
                .FirstOrDefault(a => a.Id == id)
                ?? throw new BussinessException("Message not found with the provided ID");

            _context.MessageModel.Remove(msgToRemove);
            _context.SaveChanges();
        }
    }
}
