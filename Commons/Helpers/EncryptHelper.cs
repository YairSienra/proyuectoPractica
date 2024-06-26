﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Helpers
{
    public class EncryptHelper
    {
        private static string hash 
        { 
            get 
            { 
                return "b14ca5898a4e4133bbce2ea2315a1916"; 
            } 
        }

        public static string Encrypt(string Password)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(hash);
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var criptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(criptoStream))
                        {
                            sw.Write(Password);
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string encryptedPassword)
        {
            byte[] passwordBytes = Convert.FromBase64String(encryptedPassword);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(hash);
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(passwordBytes))
                {
                    using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sw = new StreamReader(cryptoStream))
                        {
                            return sw.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
