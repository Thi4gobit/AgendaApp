using AgendaApp.API.Contexts;
using AgendaApp.API.Dtos;
using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repository for managing tasks in the agenda application.
    /// </summary>
    public class TarefaRepository (DataContext context)
    {
        /// <summary>
        /// Inserts a new task into the repository.
        /// </summary>
        public void Inserir(Tarefa tarefa)
        {
            context.Add(tarefa);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all tasks from the repository.
        /// </summary>
        public void Atualizar(Tarefa tarefa)
        {
            context.Update(tarefa);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all tasks from the repository.
        /// </summary>
        public void Excluir(Tarefa tarefa)
        {
            context.Remove(tarefa);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all tasks from the repository, ordered by date and time in descending order.
        /// </summary>
        public List<Tarefa> ObterPorDatas(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            return context
                .Set<Tarefa>()
                .Include(t => t.Categoria)
                .Where(t => t.DataHora >= dataHoraInicio && t.DataHora <= dataHoraFim)
                .OrderByDescending(t => t.DataHora)
                .ToList();
        }

        /// <summary>
        /// Retrieves all tasks from the repository, ordered by date and time in descending order.
        /// </summary>
        public Tarefa? ObterPorId(Guid id)
        {
            return context
                .Set<Tarefa>()
                .Include(t => t.Categoria)
                .FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Retrieves the count of tasks grouped by priority within a specified date and time range.
        /// </summary>
        public List<TarefaPrioridadeResponseDto> ObterTarefasPorPrioridade(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            return context
                .Set<Tarefa>()
                .Where(t => t.DataHora >= dataHoraInicio && t.DataHora <= dataHoraFim)
                .GroupBy(t => t.Prioridade)
                .Select(g => new TarefaPrioridadeResponseDto
                {
                    NomePrioridade = g.Key.ToString(),
                    QtdTarefas = g.Count()
                })
                .OrderByDescending(dto => dto.QtdTarefas)
                .ToList();
        }


        public List<TarefaCategoriaResponseDto> ObterTarefasPorCategoria(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            return context
                .Set<Tarefa>()
                .Include(t => t.Categoria)
                .Where(t => t.DataHora >= dataHoraInicio && t.DataHora <= dataHoraFim)
                .GroupBy(t => t.Categoria!.Nome)
                .Select(g => new TarefaCategoriaResponseDto
                {
                    NomeCategoria = g.Key,
                    QtdTarefas = g.Count()
                })
                .OrderByDescending(dto => dto.QtdTarefas)
                .ToList();
        }
    }
}
