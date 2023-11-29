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

        public async Task<UserModel> FindByIdAsync(Guid? id)
        {
            if (id == null)
            {
                throw new NullException("PLEASE! Inform Id");
            }
            return await _context.UserModel.FindAsync(id);

        }

        public async Task CreateUserAsync(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel user)
        {
            bool hasAny = await _context.UserModel.AnyAsync(a => a.NumberCellPhone == user.NumberCellPhone);
            if (!hasAny)
            {
                throw new EntityNotFoundException("Entity Not Found With Number");
            }
            _context.Update(user);
            await _context.SaveChangesAsync();
        }


        public async Task RemoveAsync(Guid? id)
        {
            if (id == null)
            {
                throw new NullException("PLEASE! Inform Number");
            }
            var user = await _context.UserModel.FindAsync(id);
            _context.UserModel.Remove(user);

            await _context.SaveChangesAsync();
        }
    }



}
