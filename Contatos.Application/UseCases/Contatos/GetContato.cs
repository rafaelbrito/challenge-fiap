using Contatos.Application.DTOs;
using Contatos.Application.Interfaces;
using Contatos.Application.Services;
using Contatos.Core.Domain.Interfaces;

namespace Contatos.Application.UseCases.Contatos
{
    public class GetContato
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IServiceCache _serviceCache;

        public GetContato(IContatoRepository contatoRepository, IServiceCache serviceCache)
        {
            _contatoRepository = contatoRepository;
            _serviceCache = serviceCache;

        }

        public async Task<IEnumerable<ContatoDto?>> GetAllContatosAsync()
        {
            var cacheKey = "contatos_lista";

            if (_serviceCache.TryGetValue(cacheKey, out IEnumerable<ContatoDto> contatos))
            {
                return contatos;
            }

            var contatosDoBanco = await _contatoRepository.GetAllAsync();

            contatos = contatosDoBanco.Select(c => new ContatoDto
            {
                Id = c.Id,
                Nome = c.Nome.ToString(),
                Email = c.Email,
                Telefone = c.Telefone.ToString()
            }).ToList();

            _serviceCache.Set(cacheKey, contatos, TimeSpan.FromMinutes(10));

            return contatos;
        }

        public async Task<ContatoDto?> GetContatoByIdAsync(int id)
        {
            var contato = await _contatoRepository.GetByIdAsync(id);

            return new ContatoDto
            {
                Id = contato.Id,
                Nome = contato.Nome.ToString(),
                Email = contato.Email,
                Telefone = contato.Telefone.ToString()
            };
        }

        public async Task<IEnumerable<ContatoDto>> GetContatosByDddAsync(string ddd)
        {
            var contatos = await _contatoRepository.GetByDddAsync(ddd);

            return contatos.Select(c => new ContatoDto
            {
                Id = c.Id,
                Nome = c.Nome.ToString(),
                Email = c.Email,
                Telefone = c.Telefone.ToString()
            });
        }

        public async Task<IEnumerable<ContatoDto>> GetContatosByNomeAsync(string nome)
        {
            var contatos = await _contatoRepository.GetByNomeAsync(nome);

            return contatos.Select(c => new ContatoDto
            {
                Id = c.Id,
                Nome = c.Nome.ToString(),
                Email = c.Email,
                Telefone = c.Telefone.ToString()
            });
        }

        public async Task<IEnumerable<ContatoDto>> GetContatosByEmailAsync(string email)
        {
            var contatos = await _contatoRepository.GetByEmailAsync(email);

            return contatos.Select(c => new ContatoDto
            {
                Id = c.Id,
                Nome = c.Nome.ToString(),
                Email = c.Email,
                Telefone = c.Telefone.ToString()
            });
        }

        public async Task<IEnumerable<ContatoDto>> GetContatosByTelefoneAsync(string telefone)
        {
            var contatos = await _contatoRepository.GetByTelefoneAsync(telefone);

            return contatos.Select(c => new ContatoDto
            {
                Id = c.Id,
                Nome = c.Nome.ToString(),
                Email = c.Email,
                Telefone = c.Telefone.ToString()
            });
        }

    }
}
