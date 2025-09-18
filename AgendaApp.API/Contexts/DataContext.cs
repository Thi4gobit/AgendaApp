using AgendaApp.API.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Contexts
{
    /// <summary>
    /// Represents the data context for the Agenda application.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
