using System.Text.RegularExpressions;

namespace SyncTrader.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static PhoneNumber ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number can't be empty.");

            var phoneRegex = new Regex(@"^\d{9}$");
            if (!phoneRegex.IsMatch(phoneNumber))
                throw new ArgumentException("Phone number format is invalid.");

            return new PhoneNumber(phoneNumber);
        }
    }
}