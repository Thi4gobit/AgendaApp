using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApp.API.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA"); // nome da tabela

            builder.HasKey(t => t.Id); // chave primária

            builder.Property(t => t.Id)
                .HasColumnName("ID") // nome da coluna
                .HasColumnType("uniqueidentifier") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.Property(t => t.Nome)
                .HasColumnName("NOME") // nome da coluna
                .HasColumnType("varchar(100)") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.Property(t => t.DataHora)
                .HasColumnName("DATA_HORA") // nome da coluna
                .HasColumnType("datetime") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.Property(t => t.Prioridade)
                .HasColumnName("PRIORIDADE") // nome da coluna
                .HasColumnType("int") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.Property(t => t.CategoriaId)
                .HasColumnName("CATEGORIA_ID") // nome da coluna
                .HasColumnType("uniqueidentifier") // tipo de dado
                .IsRequired(); // obrigatório (not null)

            builder.HasOne(t => t.Categoria) // Tarefa TEM 1 Categoria
                .WithMany(c => c.Tarefas) // Categoria TEM MUITAS Tarefas
                .HasForeignKey(t => t.CategoriaId) // chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // ao excluir Categoria, excluir Tarefas relacionadas
        }
    }
}
