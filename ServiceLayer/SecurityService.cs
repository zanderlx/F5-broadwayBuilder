using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ServiceLayer
{
    public class SecurityService
    {
        /// <summary>
        /// This function uses SHA-1 to hash a plaintext.
        /// Uses the built-in Cryptography library to perform 
        /// a SHA-1 hash
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>The plaintext hashed in SHA-1</returns>
        public static string ReturnSHA1Hash(string plaintext)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            // Use the SHA1 object to encrypt the plaintext in hash
            byte[] temp = sha.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

            // Store the hashed value from bytes to string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
                // Append the hashed bytes into a String Builder
                // Transform hash to all caps using X2
                sb.Append(temp[i].ToString("X2"));

            // Return the hashed value as a string
            return sb.ToString();
        }
    }
}
