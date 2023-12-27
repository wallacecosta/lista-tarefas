using ListaTarefas.Domain.Itens;
using ListaTarefas.Domain.Tarefas;
using ListaTarefas.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Item> Itens { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
