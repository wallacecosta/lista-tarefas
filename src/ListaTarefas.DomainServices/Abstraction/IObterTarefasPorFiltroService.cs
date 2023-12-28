using ListaTarefas.Domain.Tarefas;

namespace ListaTarefas.DomainServices.Abstraction
{
    public interface IObterTarefasPorFiltroService
    {
        Task<IEnumerable<Tarefa>> Execute(FiltroTarefa filtro);
    }
}
