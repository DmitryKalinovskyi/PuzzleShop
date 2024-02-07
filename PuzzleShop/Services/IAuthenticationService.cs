using PuzzleShop.Controllers.RequestBodies;
using PuzzleShop.Models;

namespace PuzzleShop.Services
{
    public interface IAuthenticationService
    {
        User? Login(User user, string password);

        User? Login(string email, string password);

        User? Login(LoginBody loginBody);

        User Register(User user, string password);

        string GeneratePasswordHash(string password);

        bool UpdatePassword(User user, string newPassword);
    }
}
