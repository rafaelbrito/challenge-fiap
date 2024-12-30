using Contatos.Application.DTOs;
using Contatos.Application.Interfaces;
using Contatos.Application.Services;
using Contatos.Core.Domain.Interfaces;

namespace Contatos.Application.UseCases.Contatos
{
    public class UpdateContato
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IServiceCache _serviceCache;
        public UpdateContato(IContatoRepository contatoRepository, IServiceCache serviceCache)
        {
            _contatoRepository = contatoRepository;
            _serviceCache = serviceCache;
        }

        public async Task<ContatoDto> UpdateContatoAsync(int id, ContatoInputDto input)
        {
            // Obtém o contato do banco de dados
            var contato = await _contatoRepository.GetByIdAsync(id);

            if (contato == null)
            {
                throw new KeyNotFoundException($"Contato com ID {id} não encontrado.");
            }

            contato.Nome = input.Nome;
            contato.Email = input.Email;
            contato.Telefone = input.Telefone;

            await _contatoRepository.UpdateAsync(contato);

            var contatoDto = new ContatoDto
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = contato.Telefone
            };

            var cacheKey = "contatos_lista";
            _serviceCache.Set(cacheKey, await _contatoRepository.GetAllAsync(), TimeSpan.FromMinutes(10));

            return contatoDto;
        }
    }
}
