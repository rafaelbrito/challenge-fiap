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
            var endereco = "exemplo@dominio.com";

            InvalidEmailException.ThrowIfInvalid(endereco);
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Email")]
        public void Email_DeveLancarExcecao_QuandoEnderecoInvalido()
        {
            var enderecoInvalido = "endereco_invalido@com";

            var exception = Assert.Throws<InvalidEmailException>(() => InvalidEmailException.ThrowIfInvalid(enderecoInvalido));
            Assert.Equal("O formato do e-mail é inválido.", exception.Message);
        }
    }
}
