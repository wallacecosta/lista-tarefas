namespace ListaTarefas.DomainServices.Abstraction
{
    public interface IConcluirItemTarefaService
    {
        Task Execute(string id);
    }
}
