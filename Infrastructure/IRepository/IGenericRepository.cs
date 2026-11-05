namespace Application.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Create(T entity);
        IQueryable<T> GetAll();
        Task<bool> Update(T entity);
        Task<T> GetById(int id);
        Task<bool> Delete(int id);
    }
}
