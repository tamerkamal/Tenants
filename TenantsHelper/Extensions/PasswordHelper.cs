using System.Security.Cryptography;
using System.Text;

namespace Tenants.Helpers.Extensions
{
    public static class PasswordHelper
    {
        public static string GeneratePassword(int size)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            var data = new byte[size];
            using (var crypto = new RNGCryptoServiceProvider())
                crypto.GetBytes(data);

            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % chars.Length]);
            }

            return IsPassWordValid(result.ToString()) ? result.ToString() : string.Empty;
        }

        private static bool IsPassWordValid(string password)
        {
            // Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
            var upper = new System.Text.RegularExpressions.Regex("[A-Z]");
            var lower = new System.Text.RegularExpressions.Regex("[a-z]");
            var number = new System.Text.RegularExpressions.Regex("[0-9]");
            // Special is "none of the above".
            var special = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]");

            const int minLength = 8;
            const int minReqs = 3;
            const int numUpper = 1;
            const int numLower = 1;
            const int numNumbers = 1;
            const int numSpecial = 1;

            // Check the length.
            if (password.Length < minLength)
                return false;

            var reqMet = 4;
            //Check for minimum number of occurrences.
            if (upper.Matches(password).Count < numUpper)
                reqMet -= 1;
            if (lower.Matches(password).Count < numLower)
                reqMet -= 1;
            if (number.Matches(password).Count < numNumbers)
                reqMet -= 1;
            if (special.Matches(password).Count < numSpecial)
                reqMet -= 1;

            // Pass all checks.
            return reqMet >= minReqs;
        }
    }
}