using FlashcardsAPI.Data;
using FlashcardsAPI.Infrastructure.RepositoryInterface;
using FlashcardsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashcardsAPI.Infrastructure.DataRepository
{
    public class UsersRepo : IUsersRepo
    {
        private readonly FlashcardsContext _context; 
        
        public UsersRepo(FlashcardsContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            bool doesExist = await _context.Users.AnyAsync(u => u.Username == username);
            return doesExist;
        }
    }
}
