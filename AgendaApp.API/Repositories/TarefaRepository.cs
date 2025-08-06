using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repository for managing tasks in the agenda application.
    /// </summary>
    public class TarefaRepository
    {
        /// <summary>
        /// Inserts a new task into the repository.
        /// </summary>
        public void Inserir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Add(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all tasks from the repository.
        /// </summary>
        public void Atualizar(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Update(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all tasks from the repository.
        /// </summary>
        public void Excluir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Remove(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all tasks from the repository, ordered by date and time in descending order.
        /// </summary>
        public List<Tarefa> ObterPorDatas(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            using (var context = new DataContext())
            {
                return context
                    .Set<Tarefa>()
                    .Include(t => t.Categoria)
                    .Where(t => t.DataHora >= dataHoraInicio && t.DataHora <= dataHoraFim)
                    .OrderByDescending(t => t.DataHora)
                    .ToList();
            }
        }

        /// <summary>
        /// Retrieves all tasks from the repository, ordered by date and time in descending order.
        /// </summary>
        public Tarefa? ObterPorId(Guid id)
        {
            using (var context = new DataContext())
            {
                return context
                    .Set<Tarefa>()
                    .Include(t => t.Categoria)
                    .FirstOrDefault(t => t.Id == id);
            }
        }
    }
}
