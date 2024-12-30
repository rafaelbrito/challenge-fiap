using Contatos.Core.Domain.Entities.ValueObjetcts;

namespace Contatos.Core.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public Telefone Telefone { get; set; }

        public Contato(Nome nome, Email email, Telefone telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
