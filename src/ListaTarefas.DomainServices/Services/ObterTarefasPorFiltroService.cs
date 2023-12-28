using ListaTarefas.Domain.Tarefas;
using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.DomainServices.Services
{
    public class ObterTarefasPorFiltroService : IObterTarefasPorFiltroService
    {
        private readonly AppDbContext _appDbContext;

        public ObterTarefasPorFiltroService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<IEnumerable<Tarefa>> Execute(FiltroTarefa filtro)
        {
            if (filtro.Take is < 0 or >= 100)
                throw new ArgumentOutOfRangeException("Top deve ser especificado entre 1 e 100");

            if (filtro.Skip is < 0 or >= 100)
                throw new ArgumentOutOfRangeException("Skip deve ser especificado entre 1 e 100");

            var query = _appDbContext.Tarefas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.Criador))
                query = query.Where(t => t.Criador.Contains(filtro.Criador));

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
                query = query.Where(t => t.Nome == filtro.Nome);

            var listaTarefas = new List<Tarefa>();

            listaTarefas = await query
                .Include(t => t.Itens)
                .Take(filtro.Take == 0 ? 100 : filtro.Take)
                .Skip(filtro.Skip)
                .ToListAsync();

            return listaTarefas;
        }
    }
}
