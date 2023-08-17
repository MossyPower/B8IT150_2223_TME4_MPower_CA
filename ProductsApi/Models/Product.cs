using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product
    {       
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Size { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}