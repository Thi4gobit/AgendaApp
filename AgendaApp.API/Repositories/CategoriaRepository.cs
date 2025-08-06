using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repository for managing categories in the agenda application.
    /// </summary>
    public class CategoriaRepository
    {
        /// <summary>
        /// Retrieves all categories from the repository.
        /// </summary>
        public List<Categoria> ObterTodos()
        {
            using(var context = new DataContext())
            {
                return context
                    .Set<Categoria>()
                    .OrderBy(context => context.Nome)
                    .ToList();
            }
        }

        public bool CategoriaExistente(Guid id)
        {
            using (var context = new DataContext())
            {
                return context
                    .Set<Categoria>()
                    .Any(c => c.Id == id);
            }
        }
    }
}
