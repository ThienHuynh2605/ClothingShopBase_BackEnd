namespace ClothingShop.Core
{
    public class Pagination<T>
    {
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public List<T> Item { get; set; }
    }
}
