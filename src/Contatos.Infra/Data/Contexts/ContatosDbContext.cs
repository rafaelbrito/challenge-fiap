using Contatos.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Infra.Data.Contexts
{
    public class ContatosDbContext : DbContext
    {
        public ContatosDbContext(DbContextOptions<ContatosDbContext> options) : base(options) { }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContatosDbContext).Assembly);
        }
    }
}
