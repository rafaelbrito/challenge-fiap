using Contatos.Core.Domain.Entities.ValueObjetcts;
using Contatos.Core.Exceptions;

namespace Contatos.Test.Unitario.Contatos
{
    public class EmailTest
    {
        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void Email_DeveSerCriadoComSucesso_QuandoEnderecoValido()
        {
            // Arrange
            var endereco = "exemplo@dominio.com";

            // Act
            var email = new Email(endereco);

            // Assert
            Assert.Equal("exemplo@dominio.com", email.Address);
        }


        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void Email_DeveLancarExcecao_QuandoEnderecoInvalido()
        {
            var enderecoInvalido = "endereco_invalido@com";

            var exception = Assert.Throws<InvalidEmailException>(() => new Email(enderecoInvalido));
            Assert.Equal("E-mail inválido", exception.Message);
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void Email_DeveSerIgual_QuandoEnderecosForemIguais()
        {
            var email1 = new Email("exemplo@dominio.com");
            var email2 = new Email("exemplo@dominio.com");

            Assert.True(email1.Equals(email2));
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void Email_DeveSerDiferente_QuandoEnderecosForemDiferentes()
        {
            var email1 = new Email("exemplo@dominio.com");
            var email2 = new Email("diferente@dominio.com");

            Assert.False(email1.Equals(email2));
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void Email_DeveSerConvertidoParaStringCorretamente()
        {
            var email = new Email("exemplo@dominio.com");

            string endereco = email;

            Assert.Equal("exemplo@dominio.com", endereco);
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void String_DeveSerConvertidoParaEmailCorretamente()
        {
            string endereco = "exemplo@dominio.com";

            Email email = endereco;

            Assert.Equal("exemplo@dominio.com", email.Address);
        }
    }
}
