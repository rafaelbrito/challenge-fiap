using Contatos.Core.Domain.Entities.ValueObjetcts;
using Contatos.Core.Exceptions;

namespace Contatos.Test.Unitario.Contatos
{
    public class NomeTest
    {
        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Nome")]
        public void Nome_DeveSerCriadoComSucesso_QuandoNomeValido()
        {
            var nome = "João Silva";

            var nomeObj = new Nome(nome);

            Assert.Equal(nome, nomeObj.Name);
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Nome")]
        public void Nome_DeveLancarExcecao_QuandoNomeInvalido()
        {
            var nomeInvalido = ""; // Nome vazio

            var exception = Assert.Throws<InvalidNomeException>(() => new Nome(nomeInvalido));
            Assert.Equal("Nome inválido", exception.Message);
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Nome")]
        public void Nome_DeveSerIgual_QuandoNomesForemIguais()
        {
            var nome1 = new Nome("João Silva");
            var nome2 = new Nome("João Silva");

            Assert.True(nome1.Equals(nome2));
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Nome")]
        public void Nome_DeveSerDiferente_QuandoNomesForemDiferentes()
        {
            var nome1 = new Nome("João Silva");
            var nome2 = new Nome("Maria Souza");

            Assert.False(nome1.Equals(nome2));
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Nome")]
        public void Nome_DeveSerConvertidoParaStringCorretamente()
        {
            var nome = new Nome("João Silva");

            string nomeString = nome;

            Assert.Equal("João Silva", nomeString);
        }

        [Fact]
        [Trait("Category", "ValueObject")]
        [Trait("ValueObject", "Nome")]
        public void String_DeveSerConvertidoParaNomeCorretamente()
        {
            string nome = "João Silva";

            Nome nomeObj = nome;

            Assert.Equal("João Silva", nomeObj.Name);
        }
    }
}
