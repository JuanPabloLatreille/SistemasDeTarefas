using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;

namespace SistemasDeTarefas.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAllUsuarios();
        Task<UsuarioModel> GetById(int id);
        Task<UsuarioDTO> Add(UsuarioDTO usuario);
        Task<UsuarioDTO> Update(UsuarioDTO usuario, int id);
        Task<bool> Delete(int id);
    }
}
