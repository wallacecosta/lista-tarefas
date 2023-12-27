using ListaTarefas.Domain.Tarefas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaTarefas.Repositories.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(k => k.TarefaId);

            builder.Property(p => p.Criador)
                .IsRequired();

            builder.Property(p => p.Nome)
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("int");
        }
    }
}