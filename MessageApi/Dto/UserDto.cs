namespace MessageAPI.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long NumberCellPhone { get; set; }
        public string Email { get; set; }

        public UserDto()
        {
        }

        public UserDto(Guid id, string name, long numberCellPhone, string email)
        {
            Id = id;
            Name = name;
            NumberCellPhone = numberCellPhone;
            Email = email;
        }
    }
}
