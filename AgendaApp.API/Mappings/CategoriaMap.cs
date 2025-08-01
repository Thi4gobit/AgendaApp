using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApp.API.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA"); // nome da tabela

            builder.HasKey(c => c.Id); // chave primária

            builder.Property(c => c.Id)
                .HasColumnName("ID") // nome da coluna
                .HasColumnType("uniqueidentifier") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.Property(c => c.Nome)
                .HasColumnName("NOME") // nome da coluna
                .HasColumnType("varchar(50)") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.HasIndex(c => c.Nome) // índice para a coluna Nome
                .IsUnique(); // índice único para o nome
        }
    }
}
