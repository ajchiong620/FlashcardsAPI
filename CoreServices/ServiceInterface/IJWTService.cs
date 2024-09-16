using FlashcardsAPI.Models;

namespace FlashcardsAPI.CoreServices.ServiceInterface
{
    public interface IJWTService
    {
        string GenerateJwtToken(User user);
    }
}
