using ClothingShop.Core.Common;

namespace ClothingShop.Core.Entities
{
    public class UserAccount : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User User { get; set; }
    }
}
