using Application.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _ctx;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }

        public async Task<bool> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
