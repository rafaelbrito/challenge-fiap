using Contatos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Test.Integracao.Contatos
{
    public class DbContextFixture
    {
        public ContatosDbContext CreateDbContext(bool preserveData = false)
        {
            var dbContext = new ContatosDbContext(
                new DbContextOptionsBuilder<ContatosDbContext>()
                .UseInMemoryDatabase(databaseName: "integration-tests-db")
                .Options
                );
            if (preserveData == false)
                dbContext.Database.EnsureDeleted();
            return dbContext;
        }
    }
}
