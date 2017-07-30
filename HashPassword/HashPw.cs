using System;
using System.Security.Cryptography;

namespace HashPassword
{
    public class HashPw
    {
        private const int DeriveBytesIterationsCount = 10000;

        public string GetSalt()
        {
            var saltInBytes = new byte[40];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltInBytes);
            return Convert.ToBase64String(saltInBytes);
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public string GetHash(string password, string salt)
        {
            var hash = new Rfc2898DeriveBytes(password, GetBytes(salt), 1000);
            return Convert.ToBase64String(hash.GetBytes(40));
        }
    }
}
