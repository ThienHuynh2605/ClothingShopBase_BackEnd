using ClothingShop.Core.Entities;

namespace ClothingShop.Application.DTOs
{
    public class ProductImageDto:BaseDto
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
