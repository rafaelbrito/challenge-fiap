﻿using Contatos.Application.DTOs;
using Contatos.Application.Interfaces;
using Contatos.Core.Domain.Entities;
using Contatos.Core.Domain.Interfaces;

namespace Contatos.Application.UseCases.Contatos
{
    public class CreateContato
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IServiceCache _serviceCache;
        public CreateContato(IContatoRepository contatoRepository, IServiceCache serviceCache)
        {
            _contatoRepository = contatoRepository;
            _serviceCache = serviceCache;

        }
        public async Task<ContatoDto> CreateAsync(ContatoInputDto input)
        {
            var contato = new Contato(input.Nome, input.Email, input.Telefone);

            var contatoAdicionado = await _contatoRepository.AddAsync(contato);

            var contatoDto = new ContatoDto
            {
                Id = contatoAdicionado.Id,
                Nome = contatoAdicionado.Nome,
                Email = contatoAdicionado.Email,
                Telefone = contatoAdicionado.Telefone
            };

            var cacheKey = "contatos_lista";
            _serviceCache.Set(cacheKey, await _contatoRepository.GetAllAsync(), TimeSpan.FromMinutes(10));

            return contatoDto;
        }
    }
}