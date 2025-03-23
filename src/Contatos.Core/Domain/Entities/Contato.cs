using Contatos.Core.Domain.Entities.ValueObjetcts;
using Contatos.Core.Exceptions;

namespace Contatos.Core.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Telefone Telefone { get; set; }

        public Contato() { }
        public Contato(string nome, string email, Telefone telefone)
        {
            InvalidNomeException.ThrowIfInvalid(nome);
            InvalidEmailException.ThrowIfInvalid(email);

            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
