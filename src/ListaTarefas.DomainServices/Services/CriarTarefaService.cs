using ListaTarefas.Domain.Itens;
using ListaTarefas.Domain.Tarefas;
using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.Repositories.Context;

namespace ListaTarefas.DomainServices.Services
{
    public class CriarTarefaService : ICriarTarefaService
    {
        private readonly AppDbContext _appDbContext;

        public CriarTarefaService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<Tarefa> Execute(NovaTarefa novaTarefa)
        {
            var tarefa = Tarefa.Criar(novaTarefa.Criador, novaTarefa.Nome);

            foreach (var itemNovo in novaTarefa.Items)
            {
                var item = Item.Criar(tarefa, itemNovo.Descricao);
                tarefa.AdicionarItem(item);
            }

            await _appDbContext.Tarefas.AddAsync(tarefa);
            await _appDbContext.SaveChangesAsync();

            return tarefa;
        }
    }
}
