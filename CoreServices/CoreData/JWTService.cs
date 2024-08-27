using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Server.Kestrel;

namespace FlashcardsAPI.CoreServices.CoreData
{
    //public class JWTService : IJWTService
    //{
    //    private readonly IJWTService _jwtService;
    //    private readonly IConfiguration _configuration;
    //    public JWTService(IJWTService jwtService, IConfiguration config) 
    //    {
    //        _jwtService = jwtService;
    //        _configuration = config;
    //    }

    //    //public string GenerateJwtToken(User user)
    //    //{
    //    //    var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();
    //    //    var claims = new[]
    //    //    {
    //    //        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
    //    //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
    //    //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //    //    };

    //    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes();
    //    //}
    //}
}
