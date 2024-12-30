using Contatos.Core.Domain.Entities;
using Contatos.Core.Exceptions;
using Xunit;

namespace Contatos.Test.Unitario.Contatos
{
    public class ContatoTest
    {
        [Fact]
        [Trait("Category", "Domain")]
        [Trait("Entity", "Contato")]
        public void Contato_DeveSerCriadoComSucesso_QuandoDadosValidos()
        {
            // Arrange
            var nome = "João Silva";
            var email = "joao.silva@dominio.com";
            var telefone = "(11) 987654321";

            // Act
            var contato = new Contato(nome, email, telefone);

            // Assert
            Assert.NotNull(contato);
            Assert.Equal(nome, contato.Nome);
            Assert.Equal(email, contato.Email);
            Assert.Equal(telefone, contato.Telefone);
        }

        [Fact]
        [Trait("Category", "Domain")]
        [Trait("Entity", "Contato")]
        public void Contato_DeveLancarExcecao_QuandoNomeInvalido()
        {
            var nomeInvalido = "";
            var email = "joao.silva@dominio.com";
            var telefone = "11987654321";

            var exception = Assert.Throws<InvalidNomeException>(() => new Contato(nomeInvalido, email, telefone));
            Assert.Equal("Nome inválido", exception.Message);
        }

        [Fact]
        [Trait("Category", "Domain")]
        [Trait("Entity", "Contato")]
        public void Contato_DeveLancarExcecao_QuandoEmailInvalido()
        {
            var nome = "João Silva";
            var emailInvalido = "joao.silva@dominio";
            var telefone = "11987654321";

            var exception = Assert.Throws<InvalidEmailException>(() => new Contato(nome, emailInvalido, telefone));
            Assert.Equal("E-mail inválido", exception.Message);
        }

        [Fact]
        [Trait("Category", "Domain")]
        [Trait("Entity", "Contato")]
        public void Contato_DeveLancarExcecao_QuandoTelefoneInvalido()
        {
            var nome = "João Silva";
            var email = "joao.silva@dominio.com";
            var telefoneInvalido = "11987";

            var exception = Assert.Throws<InvalidTelefoneException>(() => new Contato(nome, email, telefoneInvalido));
            Assert.Equal("Número de telefone deve conter de 8 a 9 dígitos numéricos.", exception.Message);
        }
    }
}
