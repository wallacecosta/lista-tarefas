namespace ListaTarefas.Domain.Tarefas
{
    public record FiltroTarefa(int Take, int Skip, string? Criador, string? Nome);
}
