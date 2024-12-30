using System.Text.RegularExpressions;

namespace Contatos.Core.Exceptions
{
    public partial class InvalidNomeException : Exception
    {
        private const string Pattern = @"^[a-zA-ZÀ-ÿ\s]{3,}$";
        private const string DefaultErrorMessage = "Nome inválido";

        private InvalidNomeException(string? message = DefaultErrorMessage) : base(message)
        { }

        public static void ThrowIfInvalid(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidNomeException(DefaultErrorMessage);

            if (name.Length < 2)
                throw new InvalidNomeException("O nome deve ter pelo menos 3 caracteres.");

            if (!NomeRegex().IsMatch(name))
                throw new InvalidNomeException("O nome contém caracteres inválidos.");
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex NomeRegex();
    }
}
