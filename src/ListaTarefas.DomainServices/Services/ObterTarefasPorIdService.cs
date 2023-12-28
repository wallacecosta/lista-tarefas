using ListaTarefas.Domain.Tarefas;
using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.DomainServices.Helpers;
using ListaTarefas.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.DomainServices.Services
{
    public class ObterTarefasPorIdService : IObterTarefaPorIdService
    {
        private readonly AppDbContext _appDbContext;

        public ObterTarefasPorIdService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<Tarefa?> Execute(string id)
        {
            var idTarefa = id.ToGuid();

            var tarefa = await _appDbContext.Tarefas
                .Where(t => t.TarefaId == idTarefa)
                .Include(t => t.Itens)
                .SingleOrDefaultAsync();

            return tarefa;
        }
    }
}
