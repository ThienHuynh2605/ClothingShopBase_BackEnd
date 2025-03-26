using ClothingShop.Core.Common;
using ClothingShop.Core.Enums;

namespace ClothingShop.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo {  get; set; }
        public Role Role { get; set; }

        public UserAccount Account { get; set; }
        public List<UserAddress> Addresses { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
