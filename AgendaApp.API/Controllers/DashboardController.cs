using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet("tarefas-prioridade/{dataHoraInicio}/{dataHoraFim}")]
        public IActionResult GetTarefasPorPrioridade(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            var tarefaRepository = new TarefaRepository();
            var response = tarefaRepository.ObterTarefasPorPrioridade(dataHoraInicio, dataHoraFim);

            if(!response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("tarefas-categoria/{dataHoraInicio}/{dataHoraFim}")]
        public IActionResult GetTarefasCategoria(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            var tarefaRepository = new TarefaRepository();
            var response = tarefaRepository.ObterTarefasPorCategoria(dataHoraInicio, dataHoraFim);

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }
    }
}
