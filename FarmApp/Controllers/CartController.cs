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

            // 
            CartItem cartItem = cart.FirstOrDefault(c => c.ProductId == id); 
            
            if(cartItem == null)
            {
                // if the cart item is null, then add new
                cart.Add(new CartItem(product));
            }
            else
            {
                // else if the cart item is not null, then increment quantity
                cartItem.Quantity += 1;
            }

            // Add session
            HttpContext.Session.SetJson("Cart", cart);

            // Notification message
            TempData["Success"] = "The product has been added!";

            // once add, redirect to whereever we came from
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}