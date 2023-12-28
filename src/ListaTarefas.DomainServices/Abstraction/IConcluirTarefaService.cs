namespace ListaTarefas.DomainServices.Abstraction
{
    public interface IConcluirTarefaService
    {
        Task Execute(string id);
    }
}
