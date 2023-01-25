using todo_list.API.Models;

namespace todo_list.API.Data.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        public IEnumerable<Tarefa> GetTarefas();
        public Tarefa GetTarefaById(int id);
    }
}
