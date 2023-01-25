using todo_list.API.Data.Repositories.Interfaces;
using todo_list.API.Models;
using todo_list.API.Services.Interfaces;

namespace todo_list.API.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IContextRepository _context;
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(IContextRepository context, ITarefaRepository tarefaRepository)
        {
            _context = context;
            _tarefaRepository = tarefaRepository;
        }
        public async Task<bool> AddTarefa(Tarefa model)
        {
            try
            {
                if (model == null) return false;
                _context.Add(model);
                if(await _context.SaveChangesAsync())
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteTarefa(int id)
        {
            try
            {
                var tarefa = _tarefaRepository.GetTarefaById(id);
                if (tarefa == null) return false;
                _context.Delete(tarefa);
                if (await _context.SaveChangesAsync())
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Tarefa GetTarefaById(int id)
        {
            try
            {
                var tarefa = _tarefaRepository.GetTarefaById(id);
                if (tarefa == null) return null;
                return tarefa;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Tarefa> GetTarefas()
        {
            try
            {
                var tarefas = _tarefaRepository.GetTarefas();
                if (tarefas == null || !tarefas.Any()) return null;
                return tarefas;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateTarefa(int id, Tarefa model)
        {
            try
            {
                var tarefa = _tarefaRepository.GetTarefaById(id);
                if (tarefa == null) return false;
                model.Id = tarefa.Id;
                _context.Update(model);
                if(await _context.SaveChangesAsync())
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
