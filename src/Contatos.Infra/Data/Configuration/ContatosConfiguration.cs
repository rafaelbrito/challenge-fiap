using Contatos.Core.Domain.Entities;
using Contatos.Core.Domain.Entities.ValueObjetcts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);                      

        builder.OwnsOne(c => c.Telefone, telefone =>
        {
            telefone.Property(t => t.Ddd).HasColumnName("Ddd");
            telefone.Property(t => t.Numero).HasColumnName("Numero");
        });

        builder.HasIndex(c => c.Nome);
    }
}
