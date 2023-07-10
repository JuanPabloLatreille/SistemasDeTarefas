using SistemasDeTarefas.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemasDeTarefas.Models.DTOs
{
    public class TarefaDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }
    }
}
