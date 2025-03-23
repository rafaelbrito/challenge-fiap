using Contatos.Core.Exceptions;

namespace Contatos.Core.Domain.Entities.ValueObjetcts
{
    public class Telefone
    {
        public string Ddd { get; }
        public string Numero { get; }

        public Telefone(string ddd, string numero)
        {
            Ddd = ddd;
            Numero = numero;
            InvalidTelefoneException.ThrowIfInvalid(ddd, numero);
        }

    
        public static implicit operator string(Telefone numero)
          => numero.ToString();

        public static implicit operator Telefone(string telefone)
        {
            telefone = telefone.Replace("(", "").Replace(")", "").Replace(" ", "");
            string ddd = telefone.Substring(0, 2);
            string numero = telefone.Substring(2);
            return new Telefone(ddd, numero);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Telefone other) return false;
            return Ddd == other.Ddd && Numero == other.Numero;
        }

        public override int GetHashCode() => HashCode.Combine(Ddd, Numero);

        public override string ToString() => $"({Ddd}) {Numero}";
    }
}
