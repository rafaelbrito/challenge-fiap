using System.Text.RegularExpressions;

namespace Contatos.Core.Exceptions
{
    public partial class InvalidTelefoneException : Exception
    {
        private const string DddPattern = @"^\d{2}$"; 
        private const string TelefonePattern = @"^\d{8,9}$"; 

        private const string DefaultErrorMessage = "DDD ou número de telefone inválido";

        private InvalidTelefoneException(string? message = DefaultErrorMessage) : base(message)
        { }

        public static void ThrowIfInvalid(string ddd, string numero)
        {
            if (string.IsNullOrWhiteSpace(ddd))
                throw new InvalidTelefoneException("DDD é obrigatório.");

            if (!DddRegex().IsMatch(ddd))
                throw new InvalidTelefoneException("DDD deve conter exatamente 2 dígitos numéricos.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new InvalidTelefoneException("Número de telefone é obrigatório.");

            if (!TelefoneRegex().IsMatch(numero))
                throw new InvalidTelefoneException("Número de telefone deve conter de 8 a 9 dígitos numéricos.");
        }

        [GeneratedRegex(DddPattern)]
        private static partial Regex DddRegex();

        [GeneratedRegex(TelefonePattern)]
        private static partial Regex TelefoneRegex();
    }
}
