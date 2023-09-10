using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("/api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext _context;

        public ProductsController(ProductsDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetProducts(
            int pageNumber = 1, // default pageNumber = 1
            int pageSize = 10, // Default nr of items per page = 10
            string? sortBy = null, // default sortBy value = null
            string? search = null) // default search value = null
        {
            // initialise query variable with all products retrived from the Db
            var query = _context.Products.AsQueryable();

            // search
            // If search parameter is not null, them 
            if (!string.IsNullOrEmpty(search))
            {
                // Search the Products Db Title attribute for any value matching the search parameter value 
                query = query.Where(p => EF.Functions.Like(p.Title, $"%{search}%"));
            }

            // Sorting
            // If the sortBy parameter contains a value, then;
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                // Sort by title, asending
                if (sortBy == "Title")
                {
                    query = query.OrderBy(p => p.Title);
                }
                // sort by category, asending
                else if (sortBy == "Category")
                {
                    query = query.OrderBy(p => p.Category);
                }
            }

            // Pagination
            // Count nr of objects contained in the DB
            var totalItems = query.Count();
            
            // Calculate total number of pages needed to display all products, initialise totalPages with the value
            // Calculate depending on number of products that can be displayed per page (default pageSize = 10)
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            
            // Calculate number of items in the db to skip based on number of items per page
            var itemsToSkip = (pageNumber - 1) * pageSize;

            // Initialise products list with number of items that can fit on a single page (pageSize), skip remaining items
            var products = query.Skip(itemsToSkip).Take(pageSize).ToList();

            // Return paginated metadata and list of products to the main application
            return Ok(new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Products = products
            });
        }

        // GET: api/Products/5 (Read / return products by ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5  (Edit / update or change products by ID)
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Products (Crete new products)
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'ProductsDbContext.Products'  is null.");
          }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5 (Delete products by ID)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
