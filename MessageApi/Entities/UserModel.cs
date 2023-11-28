namespace MessageAPI.Entities
{
    public class UserModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long NumberCellPhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<MessageModel> Message { get; set; } = new List<MessageModel>();

        public UserModel()
        {
            Id = Guid.NewGuid();
        }

        public UserModel(Guid id, string name, long numberCellPhone, string email, string password)

        {
            Id = Guid.NewGuid();
            Name = name;
            NumberCellPhone = numberCellPhone;
            Email = email;
            Password = password;
        }

        public void SendMessage(MessageModel msg)
        {
            Message.Add(msg);
        }

        public override bool Equals(object? obj)
        {
            return obj is UserModel model &&
                   Id.Equals(model.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }


}
