using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAllUsuarios();
        Task<UsuarioModel> GetById(int id);
        Task<UsuarioModel> Add(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
