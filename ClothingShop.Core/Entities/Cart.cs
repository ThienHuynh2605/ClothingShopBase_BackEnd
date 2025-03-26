using ClothingShop.Core.Common;

namespace ClothingShop.Core.Entities
{
    public class Cart : BaseEntity
    {
        public double Cost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
