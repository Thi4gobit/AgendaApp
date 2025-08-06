using System.ComponentModel.DataAnnotations;
using AgendaApp.API.Enums;

namespace AgendaApp.API.Dtos
{
    public class TarefaRequestDto
    {
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "O nome deve ter pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa")]
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "A data deve estar no formato 'yyyy-MM-dd'.")]
        [Required(ErrorMessage = "Por favor, informe a data da tarefa")]
        public string? Data { get; set; }

        [RegularExpression(@"^\d{2}:\d{2}$", ErrorMessage = "A data deve estar no formato 'HH:mm'.")]
        [Required(ErrorMessage = "Por favor, informe a hora da tarefa")]
        public string? Hora { get; set; }

        [Range(1,3, ErrorMessage = "A prioridade deve ser (1) Alta ou (2) Média ou (3) Baixa")]
        [Required(ErrorMessage = "Por favor, informe a prioridade da tarefa")]
        public int? Prioridade { get; set; }


        [Required(ErrorMessage = "Por favor, informe a categoria da tarefa")]
        public Guid? CategoriaId { get; set; }
    }
}
