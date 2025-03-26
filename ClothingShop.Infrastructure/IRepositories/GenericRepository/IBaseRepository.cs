namespace ClothingShop.Infrastructure.IRepositories.GenericRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(T entity);
        Task RestoreAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
