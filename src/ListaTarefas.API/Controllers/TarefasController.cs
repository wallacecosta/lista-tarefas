using ListaTarefas.Domain.Itens;
using ListaTarefas.Domain.Tarefas;
using ListaTarefas.DomainServices.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IObterTarefasPorFiltroService _obterTarefasPorFiltroService;
        private readonly IObterTarefaPorIdService _obterTarefaPorIdService;
        private readonly ICriarTarefaService _criarTarefaService;
        private readonly ICriarItemDaTarefaService _criarItemDaTarefaService;
        private readonly IConcluirTarefaService _concluirTarefaService;
        private readonly IConcluirItemTarefaService _concluirItemTarefaService;
        private readonly IExcluirTarefaService _excluirTarefaService;

        public TarefasController(
            IObterTarefasPorFiltroService obterTarefasPorFiltroService,
            IObterTarefaPorIdService obterTarefaPorIdService,
            ICriarTarefaService criarTarefaService,
            ICriarItemDaTarefaService criarItemDaTarefaService,
            IConcluirTarefaService concluirTarefaService,
            IConcluirItemTarefaService concluirItemTarefaService,
            IExcluirTarefaService excluirTarefaService)
        {
            _obterTarefasPorFiltroService = obterTarefasPorFiltroService;
            _obterTarefaPorIdService = obterTarefaPorIdService;
            _criarTarefaService = criarTarefaService;
            _criarItemDaTarefaService = criarItemDaTarefaService;
            _concluirTarefaService = concluirTarefaService;
            _concluirItemTarefaService = concluirItemTarefaService;
            _excluirTarefaService = excluirTarefaService;
        }

        [HttpGet("obter-filtro")]
        public async Task<IActionResult> ObterPorFiltro([FromQuery] FiltroTarefa filtro)
            => Ok(await _obterTarefasPorFiltroService.Execute(filtro));

        [HttpGet("obter-por-id")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var tarefa = await _obterTarefaPorIdService.Execute(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPost("criar-tarefa")]
        public async Task<IActionResult> CriarTarefa([FromBody] NovaTarefa request)
            => Ok(await _criarTarefaService.Execute(request));

        [HttpPatch("add-item")]
        public async Task<IActionResult> CriarItem([FromBody] AdicionarItem request)
            => Ok(await _criarItemDaTarefaService.Execute(request));

        [HttpPatch("concluir-item/{id}")]
        public async Task<IActionResult> ConcluirItem([FromRoute] string id)
        {
            await _concluirItemTarefaService.Execute(id);
            return Ok();
        }

        [HttpPatch("concluir-tarefa/{id}")]
        public async Task<IActionResult> ConcluirTarefa([FromRoute] string id)
        {
            await _concluirTarefaService.Execute(id);
            return Ok();
        }

        [HttpDelete("excluir-tarefa/{id}")]
        public async Task<IActionResult> Excluir([FromRoute] string id)
        {
            await _excluirTarefaService.Execute(id);
            return Ok();
        }
    }
}
