using Microsoft.AspNetCore.Mvc;
using FarmApp.Data;
using FarmApp.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace FarmApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHttpClientFactory _clientFactory;

        public ProductsController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        // GET: Products
        public async Task<IActionResult> Index(
            int pageNumber = 1, 
            int pageSize = 10, 
            string sortBy = null,
            string search = null)
        {
            var apiClient = _clientFactory.CreateClient("ProductsApi");
            var apiUrl = $"api/v1/products?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={sortBy}&search={search}";

            var response = await apiClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductsViewModel>(content);

                return View(result);
            }
            else
            {
                return View(new ProductsViewModel());
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = $"/api/v1/products/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);
            
            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<Product>();
                return View(product);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle other error cases
                return StatusCode((int)response.StatusCode);
            }
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = "/api/v1/products";

            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = $"/api/v1/products/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<Product>();
                return View(product);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            
            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = $"/api/v1/products/{id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, product);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = product.Id });
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = $"/api/v1/products/{id}";

            HttpResponseMessage response = await client.GetAsync(requestUri);
            
            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<Product>();
                return View(product);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = _clientFactory.CreateClient(name: "ProductsApi");
            string requestUri = $"/api/v1/products/{id}";

            HttpResponseMessage response = await client.DeleteAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private class PaginationResult
        {
        }
    }
}
