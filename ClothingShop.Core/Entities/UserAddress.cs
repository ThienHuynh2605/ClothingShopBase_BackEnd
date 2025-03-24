using ClothingShop.Core.Common;

namespace ClothingShop.Core.Entities
{
    public class UserAddress : BaseEntity
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public User User { get; set; }
    }
}
