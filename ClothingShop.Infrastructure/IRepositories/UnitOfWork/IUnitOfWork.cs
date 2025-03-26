using ClothingShop.Core.Common;
using ClothingShop.Infrastructure.IRepositories.SpecificRepository;
using ClothingShop.Infrastructure.Repositories;

namespace ClothingShop.Infrastructure.IRepositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICartRepository Carts { get; }
        IProductRepository Products { get; }
        ICartProductRepository CartsProducts { get; }
        Task<int> SaveChangesAsync();
    }
}
