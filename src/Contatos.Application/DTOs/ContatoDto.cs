namespace Contatos.Application.DTOs
{
    public record ContatoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
    }
}
