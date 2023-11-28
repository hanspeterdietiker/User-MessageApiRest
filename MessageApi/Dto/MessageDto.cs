using MessageAPI.Entities.enums;

namespace MessageAPI.Dto
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime SentWent { get; set; }
        public MessageStatusModel Status { get; set; }

        public MessageDto()
        {
        }

        public MessageDto(Guid id, string text, DateTime sentWent, MessageStatusModel status)
        {
            Id = id;
            Text = text;
            SentWent = sentWent;
            Status = status;
        }
    }
}
