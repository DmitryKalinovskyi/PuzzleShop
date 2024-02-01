using PuzzleShop.Models;

namespace PuzzleShop.Services
{
    public interface IAuthenticationService
    {
        User? Login(string email, string password);

        User Register(User user, string password);

        string GeneratePasswordHash(string password);
    }
}
