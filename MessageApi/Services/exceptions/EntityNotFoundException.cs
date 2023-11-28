namespace MessageAPI.Services.exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message) : base(message)
        {

        }
    }
}
