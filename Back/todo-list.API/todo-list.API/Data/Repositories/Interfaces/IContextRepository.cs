namespace todo_list.API.Data.Repositories.Interfaces
{
    public interface IContextRepository
    {
        public void Add<T>(T entity);
        public void Update<T>(T entity);
        public void Delete<T>(T entity);
        public Task<bool> SaveChangesAsync();
    }
}
