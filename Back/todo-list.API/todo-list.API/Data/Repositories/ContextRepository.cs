using todo_list.API.Data.Repositories.Interfaces;
using todo_list.API.Models;

namespace todo_list.API.Data.Repositories
{
    public class ContextRepository : IContextRepository
    {
        private readonly AppDbContext _context;
        public ContextRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }
    }
}
