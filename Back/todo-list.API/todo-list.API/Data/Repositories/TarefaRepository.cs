using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using todo_list.API.Data.Repositories.Interfaces;
using todo_list.API.Models;

namespace todo_list.API.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
        }
        public Tarefa GetTarefaById(int id)
        {
            return _context.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tarefa> GetTarefas()
        {
            return _context.Tarefas;
        }
    }
}
