﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;
using SistemasDeTarefas.Repositories;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> GetTarefas()
        {
            var tarefas = await _tarefaRepository.GetAllTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> GetTarefaById(int id)
        {
            var tarefa = await _tarefaRepository.GetById(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> AddTarefa([FromBody] TarefaDTO tarefaDTO)
        {
            var tarefa = await _tarefaRepository.Add(tarefaDTO);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> UpdateTarefa([FromBody] TarefaDTO tarefaDTO, int id)
        {
            var tarefa = await _tarefaRepository.Update(tarefaDTO, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> DeleteTarefa([FromRoute] int id)
        {
            bool delete = await _tarefaRepository.Delete(id);
            return Ok(delete);
        }
    }
}
