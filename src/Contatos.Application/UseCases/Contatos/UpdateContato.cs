using Contatos.Application.DTOs;
using Contatos.Core.Domain.Interfaces;
using Contatos.Core.Interfaces;

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

        public async Task<ContatoDto> UpdateContatoAsync(UpdateContatoInput input)
        {
            var contato = await _contatoRepository.GetByIdAsync(input.Id);

            if (contato == null)
            {
                throw new KeyNotFoundException($"Contato com ID {input.Id} não encontrado.");
            }

            if (!string.IsNullOrEmpty(input.Nome))
            {
                contato.Nome = input.Nome;
            }

            if (!string.IsNullOrEmpty(input.Email))
            {
                contato.Email = input.Email;
            }

            if (!string.IsNullOrEmpty(input.Telefone))
            {
                contato.Telefone = input.Telefone;
            }

            await _contatoRepository.UpdateAsync(contato);

            var contatoDto = new ContatoDto
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email,
                Numero = contato.Telefone.Numero,
                Ddd = contato.Telefone.Ddd
            };

            var cacheKey = "contatos_lista";
            _serviceCache.Set(cacheKey, await _contatoRepository.GetAllAsync(), TimeSpan.FromMinutes(10));

            return contatoDto;
        }
    }
}
