using Argon2LoginWPF.Models;
using Konscious.Security.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Argon2LoginWPF.Hashing
{
   public class HashingPassword : IDisposable
    {
        /// <summary>
        /// Public field for setting salt
        /// </summary>
        public byte[] salt;
        /// <summary>
        /// Constractor for registration
        /// </summary>
        public HashingPassword()
        {
            salt = GenerateSalt();
        }

        /// <summary>
        /// Generate salt method with 32 lenght array
        /// </summary>
        /// <returns></returns>
        public  byte[] GenerateSalt()
        {
            const int saltLenght = 32;
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randumNumber = new byte[saltLenght];
                randomNumberGenerator.GetBytes(randumNumber);
                return randumNumber;
            }
        }

        /// <summary>
        /// Method for Argon2 algorythm
        /// </summary>
        /// <param name="pw"></param>
        /// <param name="salt"></param>
        /// <returns> returns enrypted bytes</returns>
        private byte[] HashPasswordWithSalt(byte[] pw, byte[] salt)
        {
            var argon2 = new Argon2d(pw);
            argon2.DegreeOfParallelism = 16;
            argon2.MemorySize = 8192;
            argon2.Iterations = 4;
            argon2.Salt = salt;
            return argon2.GetBytes(128);
        }
        /// <summary>
        /// Register method with a new Salt
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public User RegisterHash(Account account)
        {
            var newUser = new User
            {
                Name = account.Name,
                SaltedPwHash = CustomCoder.ByteArrayTostring(HashPasswordWithSalt(Encoding.UTF8.GetBytes(account.Password), salt)),
                Salt = CustomCoder.ByteArrayTostring(salt)
            };
            return newUser;

        }
        /// <summary>
        /// Login method for user salt
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public User LoginHash(Account account)
        {
            var newUser = new User
            {
                SaltedPwHash = CustomCoder.ByteArrayTostring(HashPasswordWithSalt(Encoding.UTF8.GetBytes(account.Password), salt))
            };
            return newUser;
        }

        /// <summary>
        /// Disposing after the class was used
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
