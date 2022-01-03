
using System;
using System.Security.Cryptography;
using System.Text;

namespace Base.Helpers.Extensions
{
    public static class EncryptionHelper
    {
        public static readonly string SecretKey = "tedwashere2018";

        public static string AES_128_Encrypt(string plainText, string key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            string encryptedText;
            using (RijndaelManaged AES = GetRijndaelManaged(key))
            {
                byte[] encryptedBytes = AES_128_Encrypt(plainBytes, AES);
                encryptedText = Convert.ToBase64String(encryptedBytes);
            }
            return encryptedText;
        }

        public static RijndaelManaged GetRijndaelManaged(string secretKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
            keyBytes = SHA256.Create().ComputeHash(keyBytes);

            var ivBytes = new byte[16];
            return GetRijndaelManaged(keyBytes, ivBytes);
        }

        public static RijndaelManaged GetRijndaelManaged(byte[] keyBytes, byte[] ivBytes)
        {
            return new RijndaelManaged()
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 256,
                BlockSize = 128,
                Key = keyBytes,
                IV = ivBytes
            };
        }

        private static byte[] AES_128_Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }
    }
}