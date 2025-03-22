using ClothingShop.Core.Common;

namespace ClothingShop.Core.Entities
{
    public class ProductVariant: BaseEntity
    {

        public int Color { get; set; }
        public int Size { get; set; }
        public int Stock { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

    }
}
