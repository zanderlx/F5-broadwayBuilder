using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PasswordValidatorService
    {
        public string _hashedPlaintext { get; private set; }
        public string _hashPrefix { get; private set; }
        public string _hashSuffix { get; private set; }
        public string _apiResponse { get; private set; }
        public string _hashResponse { get; private set; }
        public int _numberOfBreaches { get; private set; }

        public PasswordValidatorService(string plaintext)
        {
            _hashedPlaintext = SecurityService.ReturnSHA1Hash(plaintext);
            _hashPrefix = GetHashPrefix(_hashedPlaintext);
            _hashSuffix = GetHashSuffix(_hashedPlaintext);
            _apiResponse = ConsumePasswordAPI(_hashPrefix).Result;
            _hashResponse = FindSpecificHash(_apiResponse);
            _numberOfBreaches = GetNumberOfBreaches();
        }

        private async Task<String> ConsumePasswordAPI(string HashPrefix)
        {
            try
            {
                // Used to consume the REST Service.... use HttpClient
                HttpClient httpclient = new HttpClient();

                // Holds the response of the "Have I Been Pwned" API
                var APIResponse = await httpclient.GetAsync("https://api.pwnedpasswords.com/range/" + HashPrefix);
                // Parses the response as a string and return it
                return await APIResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // HttpRequestException is caught and message is displayed
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message : {0}", e.Message);
                return null;
            }
        }

        private string FindSpecificHash(string APIResponse)
        {

            // The location in the response HashList of the suffix that corresponds to the password we want
            int startingIndex = APIResponse.IndexOf(_hashSuffix);

            // If the hash suffix is not found in the API response, the password is secure... return null
            if (startingIndex == -1) return null;

            // If the target hash suffix is found, get its location via substring
            string TargetHash = APIResponse.Substring(startingIndex, _apiResponse.Length - startingIndex);

            // Obtains the index of a new line delimiter
            int IndexOfNewLine = TargetHash.IndexOf(Environment.NewLine);

            // Checks if there is no line break
            if (IndexOfNewLine == -1)
                // Return the last string in the response since it does not have a break line
                return TargetHash.Substring(0, APIResponse.Length - startingIndex);
            // If there is a line break
            else
                // Returns the full string in the response somewhere other than the end of the response
                return TargetHash.Substring(0, IndexOfNewLine);
        }

        private string GetHashPrefix(string SHA1HashedPlaintext)
        {
            // Obtains the first 5 chars of the hashed plaintext
            return SHA1HashedPlaintext.Substring(0, 5);
        }

        private string GetHashSuffix(string SHA1HashedPlaintext)
        {
            // Obtains the hashed plaintext excluding the first 5 chars
            return SHA1HashedPlaintext.Substring(5, SHA1HashedPlaintext.Length - 5);
        }

        private int GetNumberOfBreaches()
        {
            //Check if password was found in the api
            if (String.IsNullOrEmpty(_hashResponse)) return -1;
            // The starting index we want... start at ":"
            int start = _hashResponse.IndexOf(":") + 1;
            // The ending index we want to retrieve the remainder of the string
            int end = _hashResponse.Length - start;
            // Converts the breach frequency of the plaintext into an int and returns it
            return Int32.Parse(_hashResponse.Substring(start, end));
        }

        public bool ValidateBreachFrequencyRange(int NumOfBreaches)
        {
            // Password is secure if it is in range of 2 breaches
            int MaxNumberOfBreaches = 2;
            // Checks if the password is less than or equal to the max number of breaches
            if (NumOfBreaches <= MaxNumberOfBreaches) return true;
            else return false;
        }
    }
}
