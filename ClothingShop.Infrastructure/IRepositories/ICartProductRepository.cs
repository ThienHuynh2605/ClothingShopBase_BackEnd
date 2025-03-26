namespace ClothingShop.Infrastructure.IRepositories
{
    public interface ICartProductRepository
    {
        Task<bool> Check(int cartId, int productId);
    }
}
