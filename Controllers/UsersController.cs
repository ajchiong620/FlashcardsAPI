using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashcardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(User user)
        {
            if (await _usersService.UserExists(user.Username))
                return BadRequest("Username already exists");

            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash)
            };

            await _usersService.AddUser(newUser);
            return Ok(newUser);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult> Login(User user)
        //{
        //    var userToLookup = await _usersService.GetUserByUsername(user.Username);

        //    if (userToLookup == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, userToLookup.PasswordHash))
        //        return Unauthorized("Invalid username or password");

        //    //var token = _jwtService.GenerateJwtToken(user);

        //    //return Ok(new { Token = token });
        //}


    }
}
