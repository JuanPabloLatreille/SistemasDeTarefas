using System.ComponentModel.DataAnnotations;

namespace SistemasDeTarefas.Models.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
    }
}
