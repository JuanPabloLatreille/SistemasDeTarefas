using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
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

        public async Task<UsuarioModel> Add(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
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

            return usuarioId;
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
