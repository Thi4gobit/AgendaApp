using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController(TarefaRepository tarefaRepository) : ControllerBase
    {
        [HttpGet("tarefas-prioridade/{dataHoraInicio}/{dataHoraFim}")]
        public IActionResult GetTarefasPorPrioridade(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            var response = tarefaRepository.ObterTarefasPorPrioridade(dataHoraInicio, dataHoraFim);

            if(!response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("tarefas-categoria/{dataHoraInicio}/{dataHoraFim}")]
        public IActionResult GetTarefasCategoria(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            var response = tarefaRepository.ObterTarefasPorCategoria(dataHoraInicio, dataHoraFim);

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }
    }
}
