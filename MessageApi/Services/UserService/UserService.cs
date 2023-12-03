using MessageAPI.Dto;
using MessageAPI.Entities;
using MessageAPI.Persistence;
using MessageAPI.Services.exceptions;
using Microsoft.EntityFrameworkCore;

namespace MessageAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly MessageApiContext _context;

        public UserService(MessageApiContext context)
        {
            _context = context;
        }

        public async Task<UserDto> FindByIdAsync(Guid id)
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

        public async Task CreateUserAsync(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, UserModel user)
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

        public void RemoveUser(Guid id)
        {
            var userToRemove = _context.UserModel
                .FirstOrDefault(a => a.Id == id) 
                ?? throw new EntityNotFoundException("User not found with the provided ID");

            _context.UserModel.Remove(userToRemove);
            _context.SaveChanges();
        }
    }



}
