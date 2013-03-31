using System;
using System.Security.Cryptography;
using System.Text;
using WebApiBlog.Core.DataAccess;
using WebApiBlog.Models;
using WebApiBlog.ViewModels;

namespace WebApiBlog.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            //create couple of default users
            var salt = GenerateSalt(6);
            var saltedPass = GenerateSaltedHash(Encoding.UTF8.GetBytes("pass"), salt);
            _userRepository.Save(new User("joe", Convert.ToBase64String(saltedPass), Convert.ToBase64String(salt)));
        }

        public AuthenticationResult Authenticate(LoginModel loginModel)
        {
            var user = _userRepository.FindByUsername(loginModel.Username);
            if(user == null)
                return new AuthenticationResult();

            var saltedHash = GenerateSaltedHash(Encoding.UTF8.GetBytes(loginModel.Password),
                                                Convert.FromBase64String(user.Salt));

            if(Convert.ToBase64String(saltedHash) != user.PasswordHash)
                return new AuthenticationResult();

            return new AuthenticationResult() { IsAuthenticated = true, User = user };
        }

        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        private static byte[] GenerateSalt(int saltSize)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[saltSize];
            rng.GetBytes(buff);
            return buff;
        }
    }
}