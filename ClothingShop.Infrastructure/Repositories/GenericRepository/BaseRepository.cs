using ClothingShop.Core.Common;
using ClothingShop.Infrastructure.IRepositories.GenericRepository;
using ClothingShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Infrastructure.Repositories.GenericRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ClothingShopDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(ClothingShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet
                .Where(s => s.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
        }

        public async Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Where(s => s.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Entry(entity).CurrentValues.SetValues(entity);
            entity.UpdateAt = DateTime.Now;
            return Task.CompletedTask;
        }


        public Task SoftDeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            entity.DeleteAt = DateTime.Now;
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task RestoreAsync(T entity)
        {
            entity.IsDeleted = false;
            entity.DeleteAt = null;
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
