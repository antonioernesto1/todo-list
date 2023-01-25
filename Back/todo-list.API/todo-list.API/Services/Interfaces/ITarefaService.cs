using todo_list.API.Models;

namespace todo_list.API.Services.Interfaces
{
    public interface ITarefaService
    {
        public IEnumerable<Tarefa> GetTarefas();
        public Tarefa GetTarefaById(int id);
        public Task<bool> AddTarefa(Tarefa model);
        public Task<bool> DeleteTarefa(int id);
        public Task<bool> UpdateTarefa(int id, Tarefa model);
    }
}
