using Contatos.Core.Exceptions;

namespace Contatos.Test.Unitario.Contatos
{
    public class NomeTest
    {
        [Fact]
        [Trait("Category", "Validation")]
        [Trait("Validation", "Nome")]
        public void Nome_DeveSerValido_QuandoNomeValido()
        {
            var nome = "João Silva";  

            InvalidNomeException.ThrowIfInvalid(nome);  
        }

        [Fact]
        [Trait("Category", "Validation")]
        [Trait("Validation", "Nome")]
        public void Nome_DeveLancarExcecao_QuandoNomeInvalido()
        {
            var nomeInvalido = ""; 

            var exception = Assert.Throws<InvalidNomeException>(() => InvalidNomeException.ThrowIfInvalid(nomeInvalido));
            Assert.Equal("Nome inválido", exception.Message);
        }        
    }
}
