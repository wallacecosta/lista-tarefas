using ListaTarefas.Domain.Enums;
using ListaTarefas.Domain.Tarefas;

namespace ListaTarefas.Domain.Itens
{
    public class Item
    {
        public Guid ItemId { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Status Status { get; private set; }
        public string? Descricao { get; private set; }
        public Guid TarefaId { get; private set; }
        public virtual Tarefa? Tarefa { get; private set; }

        private Item()
        {

        }

        public static Item Criar(Tarefa tarefa, string descricao)
        {
            return new Item
            {
                ItemId = Guid.NewGuid(),
                TarefaId = tarefa.TarefaId,
                Tarefa = tarefa,
                DataCriacao = DateTime.Now,
                Status = Status.Andamento,
                Descricao = descricao
            };
        }
    }
}
