using System;
using System.Security.Cryptography;
using System.Text;

namespace DTM.Encryption
{
    public class Md5Encryption : IMd5Encryption
    {
        public Md5Encryption()
        {
            Md5 = new MD5CryptoServiceProvider();
        }

        private MD5 Md5 { get; set; }

        public string Encrypt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(@"message", nameof(text));
            }

            Md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            var result = Md5.Hash;
            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
