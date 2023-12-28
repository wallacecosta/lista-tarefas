using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.DomainServices.Helpers;
using ListaTarefas.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.DomainServices.Services
{
    public class ConcluirTarefaService : IConcluirTarefaService
    {
        private readonly AppDbContext _appDbContext;

        public ConcluirTarefaService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task Execute(string id)
        {
            var idTarefa = id.ToGuid();

            var tarefa = await _appDbContext.Tarefas
                .Where(t => t.TarefaId == idTarefa)
                .Include(t => t.Itens)
                .SingleOrDefaultAsync();

            if (tarefa == null)
                throw new ArgumentException($"Não existe tarefa para o id: {id}");

            tarefa.Concluir();

            _appDbContext.Tarefas.Update(tarefa);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
