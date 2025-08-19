namespace AgendaApp.API.Dtos
{
    /// <summary>
    /// DTO para representar a quantidade de tarefas por prioridade.
    /// </summary>
    public class TarefaPrioridadeResponseDto
    {
        public string NomePrioridade { get; set; } = string.Empty;
        public int QtdTarefas { get; set; }
    }
}
