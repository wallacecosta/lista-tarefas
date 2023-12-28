using ListaTarefas.Domain.Itens;
using ListaTarefas.Domain.Tarefas;

namespace ListaTarefas.DomainServices.Abstraction
{
    public interface ICriarItemDaTarefaService
    {
        Task<Tarefa> Execute(AdicionarItem adicionarItem);
    }
}
