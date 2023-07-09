using SistemasDeTarefas.Enums;

namespace SistemasDeTarefas.Models.DTOs
{
    public class TarefaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }
    }
}
