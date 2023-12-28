using ListaTarefas.Domain.Enums;
using ListaTarefas.Domain.Itens;

namespace ListaTarefas.Domain.Tarefas
{
    public class Tarefa
    {
        public Guid TarefaId { get; private set; }
        public string? Criador { get; private set; }
        public string? Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Status Status { get; private set; }
        public virtual List<Item>? Itens { get; private set; }

        private Tarefa()
        {

        }

        public static Tarefa Criar(string criador, string nome)
        {
            if (string.IsNullOrWhiteSpace(criador))
                throw new ArgumentNullException(nameof(criador));

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException(nameof(nome));

            var tarefa = new Tarefa
            {
                TarefaId = Guid.NewGuid(),
                Criador = criador,
                Nome = nome,
                DataCriacao = DateTime.Now,
                Status = Status.Andamento
            };
            return tarefa;
        }

        public void AdicionarItem(Item item)
        {
            if (item.TarefaId != TarefaId)
                throw new ArgumentException("Item não pertence a essa tarefa");

            if (Itens is null)
                Itens = new();

            Itens.Add(item);
        }

        public void Concluir()
            => Status = Status.Concluido;
    }
}
