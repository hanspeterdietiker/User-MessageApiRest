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

        public async Task<UserModel> FindByIdAsync(Guid id)
        {
            bool userFound = await _context.UserModel
                .AnyAsync(a => a.Id == id);
            if (!userFound)
            {
                throw new NotFoundExcepetion("User not found with the provided ID");
            }

            return await _context.UserModel.FindAsync(id);

        }

        public async Task CreateUserAsync(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel request)
        {
            bool user = await _context.UserModel
                .AnyAsync(a => a.Id == request.Id);
            if (!user)
            {
                throw new EntityNotFoundException("Entity Not Found With Id");
            }
            _context.Update(request);
            await _context.SaveChangesAsync();
        }



        public void RemoveUser(Guid id)
        {
            var userToRemove = _context.UserModel.FirstOrDefault(a => a.Id == id);

            if (userToRemove == null)
            {
                throw new NotFoundExcepetion("User not found with the provided ID");
            }

            _context.UserModel.Remove(userToRemove);
            _context.SaveChanges();
        }
    }



}
