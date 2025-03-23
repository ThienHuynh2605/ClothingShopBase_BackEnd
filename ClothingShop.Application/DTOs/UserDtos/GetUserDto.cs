namespace ClothingShop.Application.DTOs.UserDtos
{
    public class GetUserDto : UserDto
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
