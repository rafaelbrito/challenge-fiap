﻿namespace Contatos.Message.Messages
{
    public record UpdateContatoMessage
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
