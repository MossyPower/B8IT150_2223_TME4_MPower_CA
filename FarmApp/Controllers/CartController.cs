// Blender Up (2022) ASP.NET Core 6 .NET 6 Project - Shopping Cart. Available at: https:
// www.youtube.com/watch?v=sX3g6hQZ8Lw&t=2705s&ab_channel=BlenderUp 

using Microsoft.AspNetCore.Mvc;
using FarmApp.Infrastructure;
using FarmApp.Data;
using FarmApp.Models;

namespace FarmApp.Controllers
{
    public class CartController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        
        public CartController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        // Return Cart view
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity*x.Price)
            };

            return View(cartVM);
        }



        // GET: Products/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
        //     string requestUri = $"/api/v1/products/{id}";

        //     HttpResponseMessage response = await client.GetAsync(requestUri);
            
        //     if (response.IsSuccessStatusCode)
        //     {
        //         var product = await response.Content.ReadFromJsonAsync<Product>();
        //         return View(product);
        //     }
        //     else if (response.StatusCode == HttpStatusCode.NotFound)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         // Handle other error cases
        //         return StatusCode((int)response.StatusCode);
        //     }
        // }



        // Add to Cart
        public async Task<IActionResult> Add(int id)
        {
            
            // Find the product by Id from the products Api (Id passed from url)
            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = $"/api/v1/products/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);
            
            var product = await response.Content.ReadFromJsonAsync<Product>();

            // Get the cart
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // search for the cartItem in cart by id
            CartItem cartItem = cart.FirstOrDefault(c => c.ProductId == id); 
            
            if(cartItem == null)
            {
                // if the cart item is null, then add new a new cartItem of that id
                cart.Add(new CartItem(product));
            }
            else
            {
                // else if the cartItem is not null, then increment the qty of the product
                cartItem.Quantity += 1;
            }

            // Add session
            HttpContext.Session.SetJson("Cart", cart);

            // Notification message
            TempData["Success"] = "The product has been added!";

            // once add, redirect to whereever we came from
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // Decrease the Qty of cartItem in the car
        public async Task<IActionResult> Decrease(int id)
        {
            // Get the cart
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            // search for the cartItem in cart by id
            CartItem cartItem = cart.FirstOrDefault(c => c.ProductId == id); 
            
            // if the cartItem is more than 1;
            if(cartItem.Quantity > 1)
            {
                // then reduct the cart item qty by 1
                cartItem.Quantity -= 1;
            }
            else
            {
                // else if the cartItem is 1, then remove the cartItem from the cart
                cart.RemoveAll(p => p.ProductId == id);
            }

            // check if the cart is empty
            if(cart.Count == 0)
            {
                // if cart is empty, remove the cart
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                // set the session cart again
                HttpContext.Session.SetJson("Cart", cart);
            }

            // Notification message
            TempData["Success"] = "The product has been removed!";

            // once removed, redirect to Cart index
            return RedirectToAction("index");
        }

        // Remove a cartItem from cart
        public async Task<IActionResult> Remove(int id)
        {
            // Get the cart
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            // search for the cartItem in cart by id
            CartItem cartItem = cart.FirstOrDefault(c => c.ProductId == id); 
            
            // Remove cartItem by id
            cart.RemoveAll(p => p.ProductId == id);


            // if the cartItem is empty,
            if(cart.Count == 0)
            {
                // end the session
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                // else, continue with the session
                HttpContext.Session.SetJson("Cart", cart);
            }

            // Notification message
            TempData["Success"] = "The product has been removed!";

            // once removed, redirect to Cart index
            return RedirectToAction("index");
        }
        // Clear the cart of all products
        public IActionResult Clear()
        {
            // end the session
            HttpContext.Session.Remove("Cart");

            // redirect to Cart index
            return RedirectToAction("index");
        }
    }
}