using MessageAPI.Entities.enums;
using System.ComponentModel.DataAnnotations;


namespace MessageAPI.Entities
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime SentWent  { get; set; }
        public string Text { get; set; }
        public MessageStatusModel Status { get; set; }

        public MessageModel()
        {

        }

        public MessageModel(Guid id, DateTime sentWent, string text, MessageStatusModel status)
        {
            Id = id;
            SentWent = sentWent;
            Text = text;
            Status = status;
        }

        public override bool Equals(object? obj)
        {
            return obj is MessageModel model &&
                   Id.Equals(model.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
