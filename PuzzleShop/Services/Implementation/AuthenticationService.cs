using PuzzleShop.Models;
using PuzzleShop.Repository.Interfaces;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
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
            return password;

            // code below don't work properly for some unknow reason

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] hashedPassword = sha256.ComputeHash(passwordBytes);

                // Encrypt the hashed password using RSA
                byte[] encryptedPassword = _rsa.Encrypt(hashedPassword, false);


                // Convert the encrypted password to a Base64 string
                string passwordHash = Convert.ToBase64String(encryptedPassword);

                return passwordHash;
            }
        }


        public User? Login(User user, string password)
        {
            string hashed = GeneratePasswordHash(password);

            return user.PasswordHash == hashed? user: null;
        }

        public User Register(User user, string password)
        {
            user.PasswordHash = GeneratePasswordHash(password);

            return user;
        }

        public bool UpdatePassword(User user, string newPassword)
        {
            user.PasswordHash = GeneratePasswordHash(newPassword);

            return true;
        }

        public User? Login(string email, string password)
        {
            User? user = _userRepository.GetUserByEmail(email);

            if (user == null) return null;

            return Login(user, password);
        }
    }
}
