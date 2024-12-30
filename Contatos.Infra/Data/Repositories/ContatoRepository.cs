using Contatos.Core.Domain.Entities;
using Contatos.Core.Domain.Entities.ValueObjetcts;
using Contatos.Core.Domain.Interfaces;
using Contatos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatosDbContext _context;

        public ContatoRepository(ContatosDbContext context)
        {
            _context = context;
        }

        public async Task<Contato> AddAsync(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return 0; 
            }

            _context.Contatos.Remove(contato);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<IEnumerable<Contato>> GetByDddAsync(string ddd)
        {
            return await _context.Contatos
                         .Where(x => x.Telefone.Ddd == ddd) 
                         .ToListAsync();
        }

        public async Task<IEnumerable<Contato>> GetByEmailAsync(string email)
        {
            return await _context.Contatos.Where(x => x.Email == email)
                                          .ToListAsync();
        }

        public async Task<Contato> GetByIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);            
        }

        public async Task<IEnumerable<Contato>> GetByNomeAsync(string nome)
        {
            return await _context.Contatos.Where(x => x.Nome == nome)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Contato>> GetByTelefoneAsync(string telefone)
        {
            return await _context.Contatos
                                 .Where(x => $"{x.Telefone.Ddd}{x.Telefone.Numero}" == telefone) 
                                 .ToListAsync();
        }

        public async Task<int> UpdateAsync(Contato entity)
        {
            _context.Contatos.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
