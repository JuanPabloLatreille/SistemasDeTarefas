using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;

namespace SistemasDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> GetAllTarefas();
        Task<TarefaModel> GetById(int id);
        Task<TarefaDTO> Add(TarefaDTO tarefaModel);
        Task<TarefaDTO> Update(TarefaDTO tarefaModel, int id);
        Task<bool> Delete(int id);
    }
}
