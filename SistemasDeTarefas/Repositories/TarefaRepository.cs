using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TarefaModel>> GetAllTarefas()
        {
            return await _context.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> GetById(int id)
        {
            var tarefa = await _context.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrada");
            }

            return tarefa;
        }

        public async Task<TarefaModel> Add(TarefaModel tarefaModel)
        {
            await _context.Tarefas.AddAsync(tarefaModel);
            await _context.SaveChangesAsync();

            return tarefaModel;
        }

        public async Task<TarefaModel> Update(TarefaModel tarefaModel, int id)
        {
            var tarefaId = await GetById(id);

            if (tarefaId == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            tarefaId.Name = tarefaModel.Name;
            tarefaId.Description = tarefaModel.Description;
            tarefaId.Status = tarefaModel.Status;
            tarefaId.UsuarioId = tarefaModel.UsuarioId;

            _context.Tarefas.Update(tarefaId);
            await _context.SaveChangesAsync();

            return tarefaId;
        }

        public async Task<bool> Delete(int id)
        {
            var tarefaId = _context.Tarefas.FirstOrDefault(x => x.Id == id);

            if (tarefaId == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            _context.Tarefas.Remove(tarefaId);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
