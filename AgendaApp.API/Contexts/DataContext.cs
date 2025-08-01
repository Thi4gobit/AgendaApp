using AgendaApp.API.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Contexts
{
    /// <summary>
    /// Represents the data context for the Agenda application.
    /// </summary>
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBAgenda;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
