using MessageAPI.Models;
using MessageAPI.Interfaces;
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

        public async Task<MessageModel> FindByIdAsync(Guid? id)
        {
            {
                if (id == null)
                {
                    throw new BussinessException("PLEASE! Inform Id");
                }
                return await _context.MessageModel.FindAsync(id);

            }

        }
        public async Task RemoveMessageAsync(Guid? id)
        {
            if (id == null)
            {
                throw new BussinessException("PLEASE! Inform Id");
            }
            var msg = await _context.MessageModel.FindAsync(id);
            _context.MessageModel.Remove(msg);
            await _context.SaveChangesAsync();
        }
    }
}
