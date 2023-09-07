// Blender Up (2022) ASP.NET Core 6 .NET 6 Project - Shopping Cart. Available at: https:
// www.youtube.com/watch?v=sX3g6hQZ8Lw&t=2705s&ab_channel=BlenderUp 

namespace FarmApp.Models
{
    public class CartItem
    {
        public int ProductId {get; set;}
        public string ProductName {get; set;}
        public int Quantity {get; set;}
        public decimal Price {get; set;}
        public decimal Total
        {
            get{return Quantity * Price;}
        }

        public CartItem()
        {
        }

        // initialise CartItem model object attributes with values from Products model object attributes
        public CartItem(Product product)
        {
            ProductId = product.Id;
            ProductName = product.Title;
            Price = product.Price;
            Quantity = 1;
        }
    }
}