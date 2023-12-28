using ListaTarefas.Domain.Tarefas;

namespace ListaTarefas.DomainServices.Abstraction
{
    public interface IObterTarefaPorIdService
    {
        Task<Tarefa> Execute(string id);
    }
}
