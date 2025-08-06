using AgendaApp.API.Dtos;
using AgendaApp.API.Entities;
using AgendaApp.API.Enums;
using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] TarefaRequestDto request)
        {
            //var categoriaRepository = new CategoriasController();
            var categoriaRepository = new CategoriaRepository();
            if (!categoriaRepository.CategoriaExistente(request.CategoriaId.Value))
                return NotFound(new { mensagem = "Categoria não encontrada. Verifique o ID Informado." });

            var tarefa = new Tarefa
            {
                Nome = request.Nome ?? string.Empty,
                DataHora = DateTime.Parse($"{request.Data} {request.Hora}"),
                Prioridade = (Prioridade) request.Prioridade.Value,
                CategoriaId = request.CategoriaId.Value
            };

            var tarefaRepository = new TarefaRepository();

            tarefaRepository.Inserir(tarefa);
            return StatusCode(201, new { tarefa.Id, request });
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
