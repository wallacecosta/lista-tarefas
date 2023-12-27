using ListaTarefas.Domain.Itens;

namespace ListaTarefas.Domain.Tarefas
{
    public record NovaTarefa(
        string Criador,
        string Nome,
        List<NovoItem> Items);
}
