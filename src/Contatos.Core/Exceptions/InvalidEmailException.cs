using System.Text.RegularExpressions;

namespace Contatos.Core.Exceptions
{
    public partial class InvalidEmailException : Exception
    {
        private const string Pattern = @"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9\-]+\.[a-zA-Z]{2,}$";

        private const string DefaultErrorMessage = "O formato do e-mail é inválido.";

        private InvalidEmailException(string? message = DefaultErrorMessage) : base(message)
        { }

        public static void ThrowIfInvalid(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new InvalidEmailException(DefaultErrorMessage);

            if (address.Length < 5)
                throw new InvalidEmailException(DefaultErrorMessage);

            if (!EmailRegex().IsMatch(address))
                throw new InvalidEmailException(DefaultErrorMessage);
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
