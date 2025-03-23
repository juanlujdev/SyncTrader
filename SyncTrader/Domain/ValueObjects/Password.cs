using System.Security.Cryptography;
using System.Text;

namespace SyncTrader.Domain.ValueObjects
{
    public class Password
    {
        public string HashedValue { get; private set; }

        private Password(string hashedValue)
        {
            HashedValue = hashedValue;
        }

        public static Password Create(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText) || plainText.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");

            string hashed = HashPassword(plainText);
            return new Password(hashed);
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}