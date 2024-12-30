using Contatos.Core.Exceptions;

namespace Contatos.Core.Domain.Entities.ValueObjetcts
{
    public class Nome
    {
        public string Name { get; }

        protected Nome()
        {
        }
        public Nome(string nome)
        {
            Name = nome;
            InvalidNomeException.ThrowIfInvalid(Name);
        }

        public static implicit operator string(Nome nome)
            => nome.ToString();

        public static implicit operator Nome(string nome)
            => new Nome(nome);
        public override string ToString()
            => Name;

        public override bool Equals(object obj)
        {
            if (obj is not Nome other)
                return false;

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
