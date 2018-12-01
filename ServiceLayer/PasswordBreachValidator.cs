using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PasswordBreachValidator
    {
        private static string ResponseAsString { get; set; }

        public static string SHA1_ReturnHash(string plain)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            // Use the SHA1 object to encrypt the plaintext in hash
            byte[] temp = sha.ComputeHash(Encoding.UTF8.GetBytes(plain));

            // Store the hashed value from bytes to string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
                // Append the hashed bytes into a String Builder
                // Transform hash to all caps using X2
                sb.Append(temp[i].ToString("X2"));

            // Return the hashed value as a string
            return sb.ToString();
        }

        public static string ConsumePasswordAPI(string plaintext)
        {
            // Hash the plaintext using SHA-1
            string SHA1HashedPlaintext = SHA1_ReturnHash(plaintext);
            // Obtain the first 5 characters of the SHA-1 hash
            string HashPrefix = GetHashPrefix(SHA1HashedPlaintext);
            // Obtain the hashed plaintext excluding the first 5 chars
            string HashSuffix = GetHashSuffix(SHA1HashedPlaintext);
            // The resulted value from checking the API if the hashed plaintext exists
            string ResultHash = "Lorem ipsum";

            try
            {
                // Used to consume the REST Service.... use HttpClient
                HttpClient httpclient = new HttpClient();

                // Holds the response of the "Have I Been Pwned" API
                HttpResponseMessage APIResponse = httpclient.GetAsync("https://api.pwnedpasswords.com/range/" + HashPrefix).Result;
                // Parses the response as a string
                ResponseAsString = APIResponse.Content.ReadAsStringAsync().Result;
                // The location in the response HashList of the suffix that corresponds to the password we want
                int startingIndex = ResponseAsString.IndexOf(HashSuffix);

                // If the hash suffix is not found in the API response, the password is secure... return -1
                if (startingIndex == -1) return "-1";

                // If the target hash suffix is found, get its location via substring
                string TargetHash = ResponseAsString.Substring(startingIndex, ResponseAsString.Length - startingIndex);

                // Obtains the index of a new line delimiter
                int IndexOfNewLine = TargetHash.IndexOf(Environment.NewLine);

                // Checks if there is no line break
                if (IndexOfNewLine == -1)
                    // Return the last string in the response since it does not have a break line
                    ResultHash = TargetHash.Substring(0, ResponseAsString.Length - startingIndex);
                // If there is a line break
                else
                    // Returns the full string in the response somewhere other than the end of the response
                    ResultHash = TargetHash.Substring(0, IndexOfNewLine);
            }
            catch (HttpRequestException e)
            {
                // HttpRequestException is caught and message is displayed
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message : {0}", e.Message);
            }
            // Returns the hash specific to the plaintext password from the API response
            return ResultHash;
        }

        public static string GetHashPrefix(string SHA1HashedPlaintext)
        {
            // Obtains the first 5 chars of the hashed plaintext
            return SHA1HashedPlaintext.Substring(0, 5);
        }

        public static string GetHashSuffix(string SHA1HashedPlaintext)
        {
            // Obtains the hashed plaintext excluding the first 5 chars
            return SHA1HashedPlaintext.Substring(5, SHA1HashedPlaintext.Length - 5);
        }

        public static int GetNumberOfBreaches(string plaintext)
        {
            // Retrieves the full API response
            string FullAPIResponse = ConsumePasswordAPI(plaintext);
            // The starting index we want... start at ":"
            int start = FullAPIResponse.IndexOf(":") + 1;
            // The ending index we want to retrieve the remainder of the string
            int end = FullAPIResponse.Length - start;
            // Converts the breach frequency of the plaintext into an int and returns it
            return Convert.ToInt32(FullAPIResponse.Substring(start, end));
        }

        public static bool ValidateBreachFrequencyRange(int NumOfBreaches)
        {
            int SecureRange = 2;
            if (NumOfBreaches <= SecureRange) return true;
            else return false;
        }
    }
}
