using System.Text.RegularExpressions;

namespace SyncTrader.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.");

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
                throw new ArgumentException("El formato del email no es válido.");

            return new Email(email.ToUpper());
        }
    }
}