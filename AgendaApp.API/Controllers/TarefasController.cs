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
        #region

        private readonly string _categoriaNaoEncontrado = "Categoria não encontrada. Verifique o ID Informado.";
        private readonly string _tarefaNaoEncontrado = "Tarefa não encontrada. Verifique o ID Informado.";
        private readonly string _nenhumRegistroEncontrado = "Nenhum registro encontrado.";
        #endregion

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

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TarefaRequestDto request)
        {
            var tarefaRepository = new TarefaRepository();

            var tarefa = tarefaRepository.ObterPorId(id);
            if (tarefa == null)
                return NotFound(new { mensagem = _tarefaNaoEncontrado });

            var categoriaRepository = new CategoriaRepository();
            if(!categoriaRepository.CategoriaExistente(request.CategoriaId.Value))
                return NotFound(new { mensagem = _categoriaNaoEncontrado });

            tarefa.Nome = request.Nome ?? string.Empty;
            tarefa.DataHora = DateTime.Parse($"{request.Data} {request.Hora}");
            tarefa.Prioridade = (Prioridade)request.Prioridade.Value;
            tarefa.CategoriaId = request.CategoriaId.Value;

            tarefaRepository.Atualizar(tarefa);

            return StatusCode(200, new { tarefa.Id, request });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var tarefaRepository = new TarefaRepository();

            var tarefa = tarefaRepository.ObterPorId(id);
            if (tarefa == null)
                return NotFound(new { mensagem = _tarefaNaoEncontrado });

            tarefaRepository.Excluir(tarefa);

            return StatusCode(200, new { tarefa.Id});
        }

        [HttpGet("{dataHoraInicio}/{dataHoraFim}")]
        public IActionResult GetAll(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            var tarefaRepository = new TarefaRepository();
            var tarefas = tarefaRepository.ObterPorDatas(dataHoraInicio, dataHoraFim);

            if (!tarefas.Any())
                return StatusCode(204, new { mensagem = _nenhumRegistroEncontrado });

            return StatusCode(200, tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var tarefaRepository = new TarefaRepository();
            var tarefa = tarefaRepository.ObterPorId(id);

            if (tarefa == null)
                return StatusCode(204, new { mensagem = _nenhumRegistroEncontrado });

            return StatusCode(200, tarefa);
        }
    }
}
