using ListaTarefas.Domain.Tarefas;

namespace ListaTarefas.DomainServices.Abstraction
{
    public interface ICriarTarefaService
    {
        Task<Tarefa> Execute(NovaTarefa novaTarefa);
    }
}
