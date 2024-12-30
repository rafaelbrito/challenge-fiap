using Contatos.Core.Exceptions;

namespace Contatos.Core.Domain.Entities.ValueObjetcts
{
    public class Email
    {
        public string Address { get; }

        protected Email()
        {
        }
        public Email(string address)
        {
            Address = address.ToLower().Trim();
            InvalidEmailException.ThrowIfInvalid(Address);
        }

        public static implicit operator string(Email email)
            => email.ToString();

        public static implicit operator Email(string address)
            => new Email(address);

        public override string ToString()
            => Address;

        public override bool Equals(object obj)
        {
            if (obj is not Email other)
                return false;

            return Address == other.Address;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address);
        }
    }
}
