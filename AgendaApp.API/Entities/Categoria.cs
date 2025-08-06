using System.Text.Json.Serialization;

namespace AgendaApp.API.Entities
{
    /// <summary>
    /// Represents a category in the agenda application.
    /// </summary>
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        #region Relacionamentos

        [JsonIgnore]
        public List<Tarefa> Tarefas { get; set; } = new();

        #endregion
    }
}
