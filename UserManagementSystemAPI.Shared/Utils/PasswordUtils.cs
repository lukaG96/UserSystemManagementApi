using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.Shared.Utils
{
    public class PasswordUtils
    {
        private PasswordUtils() { }

        /// <summary>
        /// Generates 10 characters long hex encoded salt.
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt() => RandomNumberGenerator.GetBytes(5).Select(x => x.ToString("x2")).Aggregate((a, b) => a + b);

        /// <summary>
        /// Generates base64 encoded salted hash.
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GenerateSaltedHash(string plainText, string salt)
        {
            HashAlgorithm algorithm = SHA256.Create();

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            byte[] plainTextWithSaltBytes = new byte[plainBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                plainTextWithSaltBytes[plainBytes.Length + i] = saltBytes[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));
        }
    }
}
