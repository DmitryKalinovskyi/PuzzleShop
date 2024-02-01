using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PuzzleShop.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        private static readonly RSACryptoServiceProvider _rsa = new(2048);

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        public string GeneratePasswordHash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashedPassword = SHA256.HashData(passwordBytes);

            // Encrypt the hashed password using RSA
            byte[] encryptedPassword = _rsa.Encrypt(hashedPassword, false);

            // Convert the encrypted password to a Base64 string
            string passwordHash = Convert.ToBase64String(encryptedPassword);

            return passwordHash;
        }


        public User? Login(string email, string password)
        {
            User? user = _userRepository.GetUserByEmail(email);

            if (user == null) return null;

            string hashed = GeneratePasswordHash(password);

            return user.PasswordHash == hashed? user: null;
        }

        public User Register(User user, string password)
        {
            user.PasswordHash = GeneratePasswordHash(password);

            return user;
        }
    }
}
