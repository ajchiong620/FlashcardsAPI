using FlashcardsAPI.Models;

namespace FlashcardsAPI.Infrastructure.RepositoryInterface
{
    public interface IUsersRepo
    {
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
        Task<bool> UserExists(string username);
    }
}
