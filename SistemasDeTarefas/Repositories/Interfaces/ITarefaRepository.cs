using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> GetAllTarefas();
        Task<TarefaModel> GetById(int id);
        Task<TarefaModel> Add(TarefaModel tarefaModel);
        Task<TarefaModel> Update(TarefaModel tarefaModel, int id);
        Task<bool> Delete(int id);
    }
}
