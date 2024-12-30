﻿using Contatos.Application.Interfaces;
using Contatos.Core.Domain.Interfaces;

namespace Contatos.Application.UseCases.Contatos
{
    public class DeleteContato
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IServiceCache _serviceCache;
        public DeleteContato(IContatoRepository contatoRepository, IServiceCache serviceCache)
        {
            _contatoRepository = contatoRepository;
            _serviceCache = serviceCache;
        }

        public async Task<int> DeleteContatoAsync(int id)
        {
            var result = await _contatoRepository.DeleteAsync(id);

            if (result > 0)
            {
                var cacheKey = "contatos_lista";
                _serviceCache.Remove(cacheKey);

                return result;
            }
            return 0;
        }
    }
}