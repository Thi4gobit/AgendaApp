using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repository for managing categories in the agenda application.
    /// </summary>
    public class CategoriaRepository (DataContext context)
    {
        /// <summary>
        /// Retrieves all categories from the repository.
        /// </summary>
        public List<Categoria> ObterTodos()
        {
            return context
                .Set<Categoria>()
                .OrderBy(context => context.Nome)
                .ToList();
        }

        public bool CategoriaExistente(Guid id)
        {
            return context
                .Set<Categoria>()
                .Any(c => c.Id == id);
        }
    }
}
