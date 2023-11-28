using MessageAPI.Entities;

namespace MessageAPI.Services.MessageService
{
    public interface IMessageService
    {
        Task CreateMessageAsync(MessageModel msg);
        Task<MessageModel> FindByIdAsync(Guid? id);
        Task RemoveMessageAsync(Guid? id);
    }
}
