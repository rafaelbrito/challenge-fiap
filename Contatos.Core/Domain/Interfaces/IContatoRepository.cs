using Contatos.Core.Domain.Entities;

namespace Contatos.Core.Domain.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<IEnumerable<Contato>> GetByDddAsync(string ddd);
        Task<IEnumerable<Contato>> GetByTelefoneAsync(string telefone);
        Task<IEnumerable<Contato>> GetByNomeAsync(string nome);
        Task<IEnumerable<Contato>> GetByEmailAsync(string email);
    }
}
