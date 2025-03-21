using ClothingShop.Core.Entities;

namespace ClothingShop.Application.DTOs
{
    public class ProductVariantDto:BaseDto
    {
        public int Color { get; set; }
        public int Size { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
