namespace AgendaApp.API.Dtos
{
    /// <summary>
    /// DTO para representar a quantidade de tarefas por categoria.
    /// </summary>
    public class TarefaCategoriaResponseDto
    {
        public string NomeCategoria { get; set; } = string.Empty;
        public int QtdTarefas { get; set; }
    }
}
