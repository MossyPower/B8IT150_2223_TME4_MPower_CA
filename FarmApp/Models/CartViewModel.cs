// Blender Up (2022) ASP.NET Core 6 .NET 6 Project - Shopping Cart. Available at: https:
// www.youtube.com/watch?v=sX3g6hQZ8Lw&t=2705s&ab_channel=BlenderUp 

namespace FarmApp.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems {get; set;}

        public decimal GrandTotal {get; set;}
    }
}