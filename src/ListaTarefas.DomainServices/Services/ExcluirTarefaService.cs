using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.DomainServices.Helpers;
using ListaTarefas.Repositories.Context;

namespace ListaTarefas.DomainServices.Services
{
    public class ExcluirTarefaService : IExcluirTarefaService
    {
        private readonly AppDbContext _appDbContext;

        public ExcluirTarefaService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task Execute(string id)
        {
            var tarefaId = id.ToGuid();
            var tarefa = await _appDbContext.Tarefas.FindAsync(tarefaId);

            if (tarefa == null)
                throw new ArgumentException($"Tarefa id: {id} não encontrada.");

            _appDbContext.Tarefas.Remove(tarefa);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
