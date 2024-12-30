using Contatos.Core.Domain.Entities;
using Contatos.Core.Domain.Entities.ValueObjetcts;
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

            modelBuilder.Entity<Contato>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contato>()
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasConversion(
                    v => v.ToString(),
                    v => new Nome(v)
                );

            modelBuilder.Entity<Contato>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasConversion(
                    v => v.ToString(),
                    v => new Email(v)
                );

            modelBuilder.Entity<Contato>()
                .Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20)  
                .HasConversion(
                    v => $"{v.Ddd}{v.Numero}",   
                    v => new Telefone(v.Substring(0, 2), v.Substring(2)) 
                );

            modelBuilder.Entity<Contato>()
                .HasIndex(c => c.Email);
        }
    }
}
