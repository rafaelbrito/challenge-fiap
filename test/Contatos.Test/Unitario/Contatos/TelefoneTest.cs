using Contatos.Core.Domain.Entities.ValueObjetcts;
using Contatos.Core.Exceptions;

public class TelefoneTests
{
    [Fact]
    [Trait("Category", "ValueObject")]
    [Trait("ValueObject", "Telefone")]
    public void Telefone_DeveSerCriadoComSucesso()
    {
        var telefone = new Telefone("11", "987654321");

        // Act
        var ddd = telefone.Ddd;
        var numero = telefone.Numero;

        Assert.Equal("11", ddd);
        Assert.Equal("987654321", numero);
    }

    [Fact]
    [Trait("Category", "ValueObject")]
    [Trait("ValueObject", "Telefone")]
    public void Telefone_DeveLancarException_QuandoInvalido()
    {
        var exception = Assert.Throws<InvalidTelefoneException>(() => new Telefone("11", "123"));
        Assert.Equal("Número de telefone deve conter de 8 a 9 dígitos numéricos.", exception.Message);
    }

    [Fact]
    [Trait("Category", "ValueObject")]
    [Trait("ValueObject", "Telefone")]
    public void Ddd_DeveLancarException_QuandoInvalido()
    {
        var exception = Assert.Throws<InvalidTelefoneException>(() => new Telefone("1", "987654321"));
        Assert.Equal("DDD deve conter exatamente 2 dígitos numéricos.", exception.Message);
    }
}
