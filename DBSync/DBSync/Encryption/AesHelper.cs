using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBSync.Encryption
{
    class AesHelper
    {
        private static Byte[] _key;
        private static Byte[] _vi;

        public static void InitAes()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key = key.CreateSubKey("DBSync");
            object aesKey = key.GetValue("ak");
            object vi = key.GetValue("avi");
            if (aesKey == null || vi == null)
            {
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                {
                    aes.GenerateIV();
                    aes.GenerateKey();

                    aesKey = aes.Key;
                    vi = aes.IV;
                    key.SetValue("ak", aesKey, RegistryValueKind.Binary);
                    key.SetValue("avi", vi, RegistryValueKind.Binary);
                }
            }
            _key = (Byte[])aesKey;
            _vi = (Byte[])vi;
        }

        public static String EncryptString(String value)
        {
            String result;
            try
            {
                byte[] encrypted = EncryptStringToBytes_Aes(value, _key, _vi);
                result = Convert.ToBase64String(encrypted);
            }
            catch
            {
                result = String.Empty;
            }

            return result;
        }

        public static String DecryptString(String value)
        {
            String result;
            try
            {
                byte[] encrypted = Convert.FromBase64String(value);
                result = DecryptStringFromBytes_Aes(encrypted, _key, _vi);
            }
            catch
            {
                result = String.Empty;
            }
            return result;
        }


        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}
