using System.ComponentModel.DataAnnotations;

namespace Contatos.Application.DTOs
{
    public record CreateContatoInput
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}
