using MessageAPI.Dto;
using MessageAPI.Models;

namespace MessageAPI.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> FindById(Guid id);
        Task CreateUser(UserModel user);
        Task AddMessageToUser(Guid id, MessageModel message);
        Task UpdateUser(Guid id, UserModel user);
        Task<MessageDto> UpdateMessageToUser(Guid id, MessageModel message);
        void RemoveUser(Guid id);
        void RemoveMessageToUser(Guid id, MessageModel message);
    }
}
