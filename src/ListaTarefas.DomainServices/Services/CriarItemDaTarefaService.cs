using ListaTarefas.Domain.Itens;
using ListaTarefas.Domain.Tarefas;
using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.DomainServices.Services
{
    public class CriarItemDaTarefaService : ICriarItemDaTarefaService
    {
        private readonly AppDbContext _appDbContext;

        public CriarItemDaTarefaService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<Tarefa> Execute(AdicionarItem adicionarItem)
        {
            if (string.IsNullOrWhiteSpace(adicionarItem.DescricaoItem))
                throw new ArgumentNullException($"{nameof(adicionarItem.DescricaoItem)} obrigatório");

            var tarefa = await _appDbContext.Tarefas
                .Where(t => t.TarefaId == adicionarItem.TarefaId)
                .Include(t => t.Itens)
                .SingleOrDefaultAsync();

            if (tarefa == null)
                throw new Exception($"Tarefa {adicionarItem.TarefaId} não encontrada");

            var item = Item.Criar(tarefa, adicionarItem.DescricaoItem);
            tarefa.AdicionarItem(item);

            await _appDbContext.Tarefas.AddAsync(tarefa);
            await _appDbContext.SaveChangesAsync();

            return tarefa;
        }
    }
}
