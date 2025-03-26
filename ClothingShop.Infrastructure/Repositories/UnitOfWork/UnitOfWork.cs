using ClothingShop.Core.Common;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.IRepositories.SpecificRepository;
using ClothingShop.Infrastructure.IRepositories.UnitOfWork;
using ClothingShop.Infrastructure.Persistence;
using ClothingShop.Infrastructure.Repositories.SpecificRepository;

namespace ClothingShop.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClothingShopDbContext _context;

        public IUserRepository Users { get; }
        public ICartRepository Carts { get; }
        public IProductRepository Products { get; }
        public ICartProductRepository CartsProducts { get; }

        public UnitOfWork(ClothingShopDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Carts = new CartRepository(context);
            Products = new ProductRepository(context);
            CartsProducts = new CartProductRepository(context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
