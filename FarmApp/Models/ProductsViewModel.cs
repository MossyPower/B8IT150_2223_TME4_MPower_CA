namespace FarmApp.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SearchTerm { get; set; }
    }
}