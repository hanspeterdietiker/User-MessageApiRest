using MessageAPI.Dto;
using MessageAPI.Models;

namespace MessageAPI.Interfaces
{
    public interface IMessageService
    {
        Task CreateMessageAsync(MessageModel msg);
        Task<MessageDto> FindByIdAsync(Guid id);
        Task<MessageDto> UpdateAsync(Guid id, MessageModel message);
        void RemoveMessageAsync(Guid id);
    }
}
