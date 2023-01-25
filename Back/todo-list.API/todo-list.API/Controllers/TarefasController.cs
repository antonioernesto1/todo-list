using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list.API.Models;
using todo_list.API.Services.Interfaces;

namespace todo_list.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tarefas = _tarefaService.GetTarefas();
                if (tarefas == null) return NotFound("Nenhuma tarefa encontrada");
                return Ok(tarefas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id inválido");

                var tarefas = _tarefaService.GetTarefaById(id);
                if (tarefas == null) return NotFound("Nenhuma tarefa encontrada");
                return Ok(tarefas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarefa model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (model == null) return BadRequest("Modelo inválido");

                if (await _tarefaService.AddTarefa(model)) return Ok("Tarefa adicionada");
                return BadRequest("Erro ao adicionar tarefa");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarefa model)
        {
            try
            {
                if (id <= 0) return BadRequest("Id inválido");

                var tarefa = _tarefaService.GetTarefaById(id);
                if (tarefa == null) return NotFound("Nenhuma tarefa encontrada");

                if (await _tarefaService.UpdateTarefa(id, model)) return Ok("Tarefa atualizada");
                return BadRequest("Erro ao atualizar tarefa!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Id inválido");
                var tarefa = _tarefaService.GetTarefaById(id);

                if (tarefa == null) return NotFound("Nenhuma tarefa encontrada");
                if (await _tarefaService.DeleteTarefa(id)) return Ok("Tarefa removida");

                return BadRequest("Erro ao remover tarefa");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
