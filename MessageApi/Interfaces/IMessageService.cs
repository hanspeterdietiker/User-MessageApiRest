using MessageAPI.Dto;
using MessageAPI.Models;

namespace MessageAPI.Interfaces
{
    public interface IMessageService
    {
        Task CreateMessage(MessageModel msg);
        Task<MessageDto> FindById(Guid id);
        Task<MessageDto> Update(Guid id, MessageModel message);
        void RemoveMessage(Guid id);
    }
}
