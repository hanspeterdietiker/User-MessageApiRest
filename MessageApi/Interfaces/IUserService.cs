using MessageAPI.Dto;
using MessageAPI.Models;

namespace MessageAPI.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> FindByIdAsync(Guid id);
        Task CreateUserAsync(UserModel user);
        Task UpdateAsync(Guid id, UserModel user);
        void RemoveUser(Guid id);
    }
}
