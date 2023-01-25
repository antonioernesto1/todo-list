using Microsoft.EntityFrameworkCore;
using todo_list.API.Models;

namespace todo_list.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
