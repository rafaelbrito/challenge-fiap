﻿namespace Contatos.Application.DTOs
{
    public record UpdateContatoInput
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
