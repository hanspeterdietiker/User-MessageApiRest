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

        public async Task CreateMessage(MessageModel msg)
        {
            _context.Add(msg);
            await _context.SaveChangesAsync();
        }

        public async Task<MessageDto> FindById(Guid id)
        {
            {
                var msgFound = _context.MessageModel
                    .AnyAsync(a => a.Id == id);

                if (msgFound == null)
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
        public async Task<MessageDto> Update(Guid id, MessageModel message)
        {
            var msgFound = await _context.MessageModel.FindAsync(id);
            if (msgFound == null)
            {
                throw new EntityNotFoundException("Entity Not Found With Id");
            }

            msgFound.Text = message.Text;
            msgFound.SentWent = message.SentWent;

            var MessageDto = new MessageDto
            {
                Id = message.Id,
                Status = message.Status,
                SentWent = message.SentWent,
                Text = message.Text
            };

            await _context.SaveChangesAsync();
            return MessageDto;
        }

        public void RemoveMessage(Guid id)
        {
            var msgToRemove = _context.MessageModel
                .FirstOrDefault(a => a.Id == id)
                ?? throw new BussinessException("Message not found with the provided ID");

            _context.MessageModel.Remove(msgToRemove);
            _context.SaveChanges();
        }
    }
}
