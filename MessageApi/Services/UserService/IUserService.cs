using MessageAPI.Entities;

namespace MessageAPI.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel> FindByIdAsync(Guid? id);
        Task CreateUserAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task RemoveAsync(Guid ? id);
    }
}
