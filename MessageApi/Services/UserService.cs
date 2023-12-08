using MessageAPI.Dto;
using MessageAPI.Interfaces;
using MessageAPI.Models;
using MessageAPI.Persistence;
using MessageAPI.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

/**
 * UserService return a Exceptions
 */
namespace MessageAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MessageApiContext _context;

        public UserService(MessageApiContext context)
        {
            _context = context;
        }

        public async Task<UserDto> FindById(Guid id)
        {
            bool userFound = await _context.UserModel
                .AnyAsync(a => a.Id == id);
            if (!userFound)
            {
                throw new EntityNotFoundException("User not found with the provided ID");
            }
            var user = await _context.UserModel.FindAsync(id);

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                NumberCellPhone = user.NumberCellPhone,
            };
            return userDto;
        }

        public async Task CreateUser(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(Guid id, UserModel user)
        {
            try
            {
                var userFound = await _context.UserModel.FindAsync(id);

                if (userFound == null)
                {
                    throw new EntityNotFoundException("Entity Not Found With Id");
                }

                userFound.Name = user.Name;
                userFound.Email = user.Email;
                userFound.Password = user.Password;
                userFound.NumberCellPhone = user.NumberCellPhone;

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException("Error during database update", dbEx);
            }

        }


        public void RemoveUser(Guid id)
        {
            try
            {
                var userToRemove = _context.UserModel
                                .FirstOrDefault(a => a.Id == id)
                                ?? throw new EntityNotFoundException("User not found with the provided ID");

                _context.UserModel.Remove(userToRemove);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException("Error during database update", dbEx);
            }

        }

        public async Task AddMessageToUser(Guid id, MessageModel message)
        {
            var user = await FindById(id);
            if (user == null)
            {
                throw new EntityNotFoundException("Entity Not Found With Id");
            }
            _context.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<MessageDto> UpdateMessageToUser(Guid id, MessageModel message)
        {
            try
            {
                var messageFound = await _context.MessageModel.FindAsync(id);
                if (messageFound == null)
                {
                    throw new EntityNotFoundException("Entity Not Found With Id");
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



        public void RemoveMessageToUser(Guid id, MessageModel message)
        {
            try
            {
                var messageToRemove = _context.MessageModel
                               .FirstOrDefault(a => a.Id == id)
                               ?? throw new BussinessException("Message not found with the provided ID");

                _context.Remove(messageToRemove);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException("Error during database update", dbEx);
            }

        }
    }



}
