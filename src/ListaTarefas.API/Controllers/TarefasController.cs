using ListaTarefas.Domain.Itens;
using ListaTarefas.Domain.Tarefas;
using ListaTarefas.Repositories.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public TarefasController(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        [HttpGet("obter-filtro")]
        public async Task<IActionResult> ObterPorFiltro([FromQuery] FiltroTarefa filtro)
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

            var listaTarefas = await query
                .Include(t => t.Itens)
                .Take(filtro.Take == 0 ? 100 : filtro.Take)
                .Skip(filtro.Skip)
                .ToListAsync();

            return Ok(listaTarefas);
        }

        [HttpGet("obter-por-id")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var tarefa = await _appDbContext.Tarefas
                .Where(t => t.TarefaId == id)
                .Include(t => t.Itens)
                .SingleOrDefaultAsync();

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] NovaTarefa novaTarefa)
        {
            var tarefa = Tarefa.Criar(novaTarefa.Criador, novaTarefa.Nome);

            foreach (var itemNovo in novaTarefa.Items)
            {
                var item = Item.Criar(tarefa, itemNovo.Descricao);
                tarefa.AdicionarItem(item);
            }

            await _appDbContext.Tarefas.AddAsync(tarefa);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { tarefa.TarefaId }, tarefa);
        }

        [HttpPatch("add-item")]
        public async Task<IActionResult> Criar([FromBody] AdicionarItem adicionarItem)
        {
            var tarefa = await _appDbContext.Tarefas
                .Where(t => t.TarefaId == adicionarItem.TarefaId)
                .Include(t => t.Itens)
                .SingleOrDefaultAsync();

            if (tarefa == null)
                return NotFound();

            var item = Item.Criar(tarefa, adicionarItem.DescricaoItem);
            tarefa.AdicionarItem(item);

            await _appDbContext.Tarefas.AddAsync(tarefa);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { tarefa.TarefaId }, tarefa);
        }
    }
}
