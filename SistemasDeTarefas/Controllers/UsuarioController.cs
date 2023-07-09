using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AddUsuario([FromBody] UsuarioDTO usuarioModel)
        {
            var usuario = await _usuarioRepository.Add(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUsuario([FromBody] UsuarioDTO usuarioModel, int id)
        {
            var usuario = await _usuarioRepository.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuario([FromRoute] int id)
        {
            bool delete = await _usuarioRepository.Delete(id);
            return Ok(delete);
        }
    }
}
