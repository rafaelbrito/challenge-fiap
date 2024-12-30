namespace Contatos.Application.DTOs
{
    public record ContatoInputDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
