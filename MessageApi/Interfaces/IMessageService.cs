using MessageAPI.Models;

namespace MessageAPI.Interfaces
{
    public interface IMessageService
    {
        Task CreateMessageAsync(MessageModel msg);
        Task<MessageModel> FindByIdAsync(Guid? id);
        Task RemoveMessageAsync(Guid? id);
    }
}
