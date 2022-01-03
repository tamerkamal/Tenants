using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Base.Helpers.Extensions
{
    public static class StringExtensions
    {
        private const string Key = "Tenants-Key";

        public static string Encrypt(this string input)
        {
            var plainText = Encoding.Unicode.GetBytes(input);
            var salt = Encoding.ASCII.GetBytes(Key);
            var secretKey = new Rfc2898DeriveBytes(Key, salt);

            // Creates a symmetric encryptor object. 
            var rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Key = secretKey.GetBytes(rijndaelCipher.KeySize / 8);
            rijndaelCipher.IV = secretKey.GetBytes(rijndaelCipher.BlockSize / 8);
            var encryptor = rijndaelCipher.CreateEncryptor();

            // Defines a stream that links data streams to cryptographic transformations
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainText, 0, plainText.Length);

            // Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            var cipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherBytes);
        }

        public static string Decrypt(this string input)
        {
            var encryptedData = Convert.FromBase64String(input);
            var salt = Encoding.ASCII.GetBytes(Key);
            var secretKey = new Rfc2898DeriveBytes(Key, salt);

            // Creates a symmetric Rijndael decryptor object.
            var rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Key = secretKey.GetBytes(rijndaelCipher.KeySize / 8);
            rijndaelCipher.IV = secretKey.GetBytes(rijndaelCipher.BlockSize / 8);
            var decryptor = rijndaelCipher.CreateDecryptor();

            // Defines the cryptographic stream for decryption.THe stream contains decrypted data
            var memoryStream = new MemoryStream(encryptedData);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            var plainText = new byte[encryptedData.Length];
            var decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
            memoryStream.Close();
            cryptoStream.Close();

            // Converting to string
            return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
        }

        public static string Compress(this string input)
        {
            var buffer = Encoding.UTF8.GetBytes(input);
            var ms = new MemoryStream();
            using (var zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;

            var compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            var gzBuffer = new byte[compressed.Length + 4];
            Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }

        public static string Decompress(this string input)
        {
            var gzBuffer = Convert.FromBase64String(input);
            using var ms = new MemoryStream();
            var msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            var buffer = new byte[msgLength];

            ms.Position = 0;
            using (var zip = new GZipStream(ms, CompressionMode.Decompress))
            {
                zip.Read(buffer, 0, buffer.Length);
            }

            return Encoding.UTF8.GetString(buffer);
        }

        public static string FirstLetterToLowerCase(this string input)
        {
            return char.ToLowerInvariant(input[0]) + input.Substring(1);
        }

        public static TEnum TryParseEnum<TEnum>(this string input) where TEnum : struct
        {
            return Enum.TryParse(input, true, out TEnum tEnumResult) ? tEnumResult : default;
        }

        public static string GetSha1Hash(this string input)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider sha1Obj = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bytesToHash = System.Text.Encoding.Default.GetBytes(input);
            bytesToHash = sha1Obj.ComputeHash(bytesToHash);
            string strResult = "";
            foreach (byte b in bytesToHash)
                strResult += b.ToString("x2");
            return strResult;
        }

        public static string GetReferenceNumber(this string input)
        {
            List<int> serialNumberArray = new List<int>();
            var modCheck = input.ToString().Length % 2;
            var loopCounter = 0;

            while (loopCounter < input.ToString().Length)
            {
                var digit = Convert.ToInt32(input.ToString().Substring(loopCounter, 1));
                serialNumberArray.Add(digit);
                loopCounter += 1;
            }

            for (int i = 0; i <= serialNumberArray.Count - 1; i++)
            {
                var check = i + 1;

                if ((check % 2) == modCheck)
                    serialNumberArray[i] = serialNumberArray[i] * 2;
            }

            loopCounter = 0;
            var checkSum = 0;

            while (loopCounter < input.ToString().Length)
            {
                var arrayItemValue = serialNumberArray[loopCounter];

                var additiveResult = 0;
                if (arrayItemValue > 9)
                    additiveResult = 1 + (arrayItemValue % 10);
                else
                    additiveResult = arrayItemValue;

                checkSum = checkSum + additiveResult;
                loopCounter += 1;
            }

            var checkDigit = 0;

            if ((checkSum % 10) > 0)
                checkDigit = 10 - (checkSum % 10);

            return $"{input.ToString()}{checkDigit}";
        }

        public static byte[] ConvertFromBase64StringToBytes(this string input)
        {
            if (string.IsNullOrEmpty(input) || input == "data:") return null;

            // Remove mime type from base64String
            if (input.Contains(";base64"))
            {
                input = RemoveIllegalCharactersFromBase64String(input);
                input = input.Substring(input.IndexOf(";base64,", StringComparison.Ordinal) + 8);
            }

            // Convert base64String to bytes[]
            return Convert.FromBase64String(input);
        }

        public static string RemoveIllegalCharactersFromBase64String(this string input)
        {
            var converted = input.Replace('-', '+');
            converted = converted.Replace('_', '/');
            converted = converted.Replace('\"', ' ');
            return converted;
        }

        public static string MD5Encrypt(this string input)
        {
            // Create New Crypto Service Provider Object
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            // Compute the Hash, returns an array of Bytes
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i <= data.Length - 1; i++)
                sBuilder.Append(data[i].ToString("x2"));

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool ExceedsAllowedLength(this string input, int maxLength)
        {
            return (!string.IsNullOrEmpty(input) && input.Length > maxLength);
        }



        public static bool IsNumeric(this string input)
        {
            return input.All(char.IsNumber);
        }

        public static bool IsDate(this string input)
        {
            try
            {
                DateTime dt = DateTime.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}