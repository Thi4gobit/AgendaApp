using AgendaApp.API.Enums;

namespace AgendaApp.API.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public Prioridade Prioridade { get; set; }
        public Guid CategoriaId { get; set; }

        #region Relacionamentos

        public Categoria Categoria { get; set; } = new();

        #endregion
    }
}
