using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product
    {       
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Size { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
   
        public string? Variety { get; set; }
        public string? Season { get; set; }
        public string? Fertiliser { get; set; }
        public string? Pesticide { get; set; }
        public string? Herbicide { get; set; }
        public string? Fungicide { get; set; }
        public string? Description { get; set; }
    }
}