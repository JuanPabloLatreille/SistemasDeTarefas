using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UsuarioRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UsuarioModel>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            var usuarioId = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário com ID: {id} não encontrado.");
            }

            return usuarioId;
        }

        public async Task<UsuarioDTO> Add(UsuarioDTO usuarioDTO)
        {
            var usuarioEntidade = _mapper.Map<UsuarioModel>(usuarioDTO);

            await _context.Usuarios.AddAsync(usuarioEntidade);
            await _context.SaveChangesAsync();

            var usuario = _mapper.Map<UsuarioDTO>(usuarioEntidade);

            return usuario;
        }
        public async Task<UsuarioDTO> Update(UsuarioDTO usuario, int id)
        {
            var usuarioId = await GetById(id);

            if (usuarioId == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            usuarioId.Name = usuario.Name;
            usuarioId.Email = usuario.Email;

            _context.Usuarios.Update(usuarioId);
            await _context.SaveChangesAsync();

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioId);

            return usuarioDTO;
        }

        public async Task<bool> Delete(int id)
        {
            var usuarioId = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuarioId == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            _context.Usuarios.Remove(usuarioId);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
