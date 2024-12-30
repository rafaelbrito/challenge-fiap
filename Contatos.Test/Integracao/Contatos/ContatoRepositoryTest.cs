using Contatos.Core.Domain.Entities;
using Contatos.Infra.Data.Contexts;
using Contatos.Infra.Data.Repositories;

namespace Contatos.Test.Integracao.Contatos
{
    public class ContatoRepositoryTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public ContatoRepositoryTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task AddAsync_DeveAdicionarContatoComSucesso()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);
            var contato = new Contato("João Silva", "joao.silva@dominio.com", "11987654321");

            // Act
            var addedContato = await _repository.AddAsync(contato);

            // Assert
            Assert.NotNull(addedContato);
            Assert.Equal("João Silva", addedContato.Nome);
            Assert.Equal("joao.silva@dominio.com", addedContato.Email);
            Assert.Equal("(11) 987654321", addedContato.Telefone.ToString());
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task DeleteAsync_DeveRemoverContatoComSucesso()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            var contato = new Contato("Maria Souza", "maria.souza@dominio.com", "11987654321");
            await _repository.AddAsync(contato);

            var result = await _repository.DeleteAsync(contato.Id);

            Assert.Equal(1, result);  
            var deletedContato = await _repository.GetByIdAsync(contato.Id);
            Assert.Null(deletedContato);  
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task GetAllAsync_DeveRetornarTodosOsContatos()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            await _repository.AddAsync(new Contato("João Silva", "joao.silva@dominio.com", "11987654321"));
            await _repository.AddAsync(new Contato("Maria Souza", "maria.souza@dominio.com", "11987654322"));

            var contatos = await _repository.GetAllAsync();

            Assert.NotEmpty(contatos);
            Assert.Equal(2, contatos.Count());
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task GetByIdAsync_DeveRetornarContatoPorId()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            var contato = new Contato("Carlos Oliveira", "carlos.oliveira@dominio.com", "11987654323");
            var addedContato = await _repository.AddAsync(contato);

            var foundContato = await _repository.GetByIdAsync(addedContato.Id);

            Assert.NotNull(foundContato);
            Assert.Equal(addedContato.Id, foundContato.Id);
            Assert.Equal("Carlos Oliveira", foundContato.Nome);
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task GetByEmailAsync_DeveRetornarContatoPorEmail()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            await _repository.AddAsync(new Contato("Carlos Oliveira", "carlos.oliveira@dominio.com", "11987654323"));
            await _repository.AddAsync(new Contato("João Silva", "joao.silva@dominio.com", "11987654321"));

            var contatos = await _repository.GetByEmailAsync("joao.silva@dominio.com");

            Assert.NotEmpty(contatos);
            Assert.Equal(1, contatos.Count());
            Assert.Equal("João Silva", contatos.First().Nome);
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task UpdateAsync_DeveAtualizarContatoComSucesso()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            var contato = new Contato("Carlos Oliveira", "carlos.oliveira@dominio.com", "11987654323");
            var addedContato = await _repository.AddAsync(contato);
            addedContato.Nome = "Carlos Souza";

            var result = await _repository.UpdateAsync(addedContato);

            Assert.Equal(1, result); 
            var updatedContato = await _repository.GetByIdAsync(addedContato.Id);
            Assert.Equal("Carlos Souza", updatedContato.Nome);
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task GetByNomeAsync_DeveRetornarContatosPorNome()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            await _repository.AddAsync(new Contato("Carlos Oliveira", "carlos.oliveira@dominio.com", "11987654323"));
            await _repository.AddAsync(new Contato("Carlos Souza", "carlos.souza@dominio.com", "11987654324"));

            var contatos = await _repository.GetByNomeAsync("Carlos Oliveira");

            Assert.NotEmpty(contatos);
            Assert.Single(contatos);
            Assert.Equal("Carlos Oliveira", contatos.First().Nome);
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task GetByTelefoneAsync_DeveRetornarContatosPorTelefone()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            await _repository.AddAsync(new Contato("Carlos Oliveira", "carlos.oliveira@dominio.com", "11987654323"));
            await _repository.AddAsync(new Contato("Maria Souza", "maria.souza@dominio.com", "11987654324"));

            var contatos = await _repository.GetByTelefoneAsync("11987654323");

            Assert.NotEmpty(contatos);
            Assert.Single(contatos);
            Assert.Equal("Carlos Oliveira", contatos.First().Nome);
        }

        [Fact]
        [Trait("Category", "ContatoRepository")]
        [Trait("Entity", "Contato")]
        public async Task GetByDddAsync_DeveRetornarContatosPorDdd()
        {
            var dbContext = _fixture.CreateDbContext();
            var _repository = new ContatoRepository(dbContext);

            await _repository.AddAsync(new Contato("Carlos Oliveira", "carlos.oliveira@dominio.com", "11987654323")); 
            await _repository.AddAsync(new Contato("Maria Souza", "maria.souza@dominio.com", "11987654324"));   
            await _repository.AddAsync(new Contato("José Santos", "jose.santos@dominio.com", "21398765432"));   
            await _repository.AddAsync(new Contato("Ana Pereira", "ana.pereira@dominio.com", "21398765433"));  

            var contatosDdd11 = await _repository.GetByDddAsync("11");

            Assert.NotEmpty(contatosDdd11);  
            Assert.Equal(2, contatosDdd11.Count());  
            Assert.All(contatosDdd11, contato => Assert.Equal("11", contato.Telefone.Ddd)); 

            Assert.DoesNotContain(contatosDdd11, contato => contato.Telefone.Ddd == "21");
        }
    }
}
