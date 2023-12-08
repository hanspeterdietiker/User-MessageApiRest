using MessageAPI.Dto;
using MessageAPI.Interfaces;
using MessageAPI.Models;
using MessageAPI.Persistence;
using MessageAPI.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

/**
 * MessageService return Exceptions
 */
namespace MessageAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageApiContext _context;

        public MessageService(MessageApiContext context)
        {
            _context = context;
        }

        public async Task CreateMessage(MessageModel message)
        {
            try
            {

            _context.Add(message);
            await _context.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                throw new DbUpdateException("Error during database update", dbEx);
            }
        }

        public async Task<MessageDto> FindById(Guid id)
        {
            {
                var messageFound = _context.MessageModel
                    .AnyAsync(a => a.Id == id);

                if (messageFound == null)
                {
                    throw new BussinessException("Message not found with the provided ID");
                }
                var message = await _context.MessageModel.FindAsync(id);

                var messageDto = new MessageDto
                {
                    Id = message.Id,
                    Status = message.Status,
                    SentWent = message.SentWent,
                    Text = message.Text
                };
                return messageDto;

            }

        }
        public async Task<MessageDto> Update(Guid id, MessageModel message)
        {
            try
            {
                var messageFound = await _context.MessageModel.FindAsync(id);
                if (messageFound == null)
                {
                    throw new BussinessException("Entity Not Found With Id");
                }

                messageFound.Text = message.Text;
                messageFound.SentWent = message.SentWent;

                var messageDto = new MessageDto
                {
                    Id = message.Id,
                    Status = message.Status,
                    SentWent = message.SentWent,
                    Text = message.Text
                };

                await _context.SaveChangesAsync();
                return messageDto;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException("Error during database update", dbEx);
            }
            
            
        }

        public void RemoveMessage(Guid id)
        {
            try
            {
            var messageToRemove = _context.MessageModel
                .FirstOrDefault(a => a.Id == id)
                ?? throw new BussinessException("Message not found with the provided ID");

            _context.MessageModel.Remove(messageToRemove);
            _context.SaveChanges();

            }
            catch(DbUpdateException dbEx)
            {
                throw new DbUpdateException("Error during database update", dbEx);
            }
        }
    }
}
