using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TarefaRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<TarefaDTO> Add(TarefaDTO tarefaDTO)
        {
            var tarefaEntidade = _mapper.Map<TarefaModel>(tarefaDTO);

            await _context.Tarefas.AddAsync(tarefaEntidade);
            await _context.SaveChangesAsync();

            var tarefa = _mapper.Map<TarefaDTO>(tarefaEntidade);

            return tarefa;
        }

        public async Task<TarefaDTO> Update(TarefaDTO tarefaDTO, int id)
        {
            var tarefaId = await GetById(id);

            if (tarefaId == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            tarefaId.Name = tarefaDTO.Name;
            tarefaId.Description = tarefaDTO.Description;
            tarefaId.Status = tarefaDTO.Status;
            tarefaId.UsuarioId = tarefaDTO.UsuarioId;

            _context.Tarefas.Update(tarefaId);
            await _context.SaveChangesAsync();

            var tarefaUpdate = _mapper.Map<TarefaDTO>(tarefaId);

            return tarefaUpdate;
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
