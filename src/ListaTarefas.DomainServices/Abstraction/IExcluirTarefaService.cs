namespace ListaTarefas.DomainServices.Abstraction
{
    public interface IExcluirTarefaService
    {
        Task Execute(string id);
    }
}
