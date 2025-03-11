namespace ClothingShop.Application.DTOs
{
    public abstract class BaseDto
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
