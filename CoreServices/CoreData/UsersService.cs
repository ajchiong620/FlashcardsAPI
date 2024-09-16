using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Infrastructure.RepositoryInterface;
using FlashcardsAPI.Models;
using System.Runtime.InteropServices;

namespace FlashcardsAPI.CoreServices.CoreData
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepo _usersRepo;
        public UsersService(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }
        public async Task AddUser(User user)
        {
            await _usersRepo.AddUser(user);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _usersRepo.GetUserByUsername(username);
        }

        public async Task<bool> UserExists(string username)
        {
            return await _usersRepo.UserExists(username);
        }
    }
}
