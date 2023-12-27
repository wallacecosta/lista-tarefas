using ListaTarefas.Domain.Itens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaTarefas.Repositories.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Itens");

            builder.HasKey(k => k.ItemId);

            builder.Property(p => p.DataCriacao)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("int");

            builder.Property(p => p.Descricao)
                .IsRequired();

            builder.HasOne(i => i.Tarefa)
                .WithMany(t => t.Itens)
                .HasForeignKey(i => i.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}