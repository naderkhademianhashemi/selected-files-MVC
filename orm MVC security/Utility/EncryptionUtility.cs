using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication1.Utility
{
    public static class EncryptionUtility
    {
        public static string Encryption(string PlainText, string key)
        {
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(PlainText);
            var bytes = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(bytes);
        }
        public static string Decryption(string CypherText, string key)
        {
            byte[] b = Convert.FromBase64String(CypherText);
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);
        }
        static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }
    }
}