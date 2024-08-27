using FlashcardsAPI.Models;

namespace FlashcardsAPI.CoreServices.ServiceInterface
{
    public interface IUsersService
    {
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
        Task<bool> UserExists(string username);

    }
}
