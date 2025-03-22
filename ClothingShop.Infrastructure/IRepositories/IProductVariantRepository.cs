using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Entities;

namespace ClothingShop.Infrastructure.IRepositories
{
    public interface IProductVariantRepository
    {
        Task<bool> CreateProductVariantAsync(ProductVariant ProductVariant);
        Task<ProductVariant> GetProductVariantByIdAsync(int id);
        Task<(List<ProductVariant> ProductVariant, int total)> GetProductVariantAsync(int page, int pageSize);
        Task<bool> UpdateProductVariantAsync(int id, ProductVariant ProductVariant);
        Task<bool> SoftDeleteProductVariantAsync(int id);
        Task<bool> RestoreProductVariantAsync(int id);
        Task<bool> DeleteProductVariantAsync(int id);
    }
}
