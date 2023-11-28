namespace MessageAPI.Dto
{
    public class UserDto
    {
        public Guid User { get; set; }
        public string Name { get; set; }
        public long NumberCellPhone { get; set; }
        public string Email { get; set; }

        public UserDto()
        {
        }

        public UserDto(Guid user, string name, long numberCellPhone, string email)
        {
            User = user;
            Name = name;
            NumberCellPhone = numberCellPhone;
            Email = email;
        }
    }
}
