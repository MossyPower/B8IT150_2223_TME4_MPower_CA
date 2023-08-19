using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;
using SQLitePCL;
using ProductsApi.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsApiPagination.Entities;
using System.Text.Json;

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

        // GET: api/Products (Read / retrun all products)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _context.Products.ToListAsync();
        }
        
        // GET alternative, using pagination
        // [HttpGet]
        // public Task<ActionResult<IEnumerable<Product>>> GetProducts(
        //     int page = 1, 
        //     int pageSize = 10
        // )
        // {
        //     if (_context.Products == null) return Task.FromResult<ActionResult<IEnumerable<Product>>>(NotFound());
            
        //     var totalCount = _context.Products.Count();
        //     var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
        //     var productsPerPage = _context.Products
        //         .Skip((page - 1) * pageSize)
        //         .Take(pageSize)
        //         .ToList();

        //     return Task.FromResult<ActionResult<IEnumerable<Product>>>(productsPerPage); 
        // }


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

        // GET by ID alternative, using pagination
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Product>> GetProduct([FromRoute]int id, [FromQuery] PaginationParams @params)
        // {
        //     // check to see if productes exist in the Db. If no product exist in the Db, return a Not Found error
        //     var product = await _context.Products.FindAsync(id);
        //     if (product == null) return NotFound();
            
        //     // return products from the Db by ID
        //     var products = _context.Products
        //         .Where(p => p.Id == id)
        //         .OrderBy(p => p.Id);

        //     // Return pagination Metadata in the Http response header
        //     var paginationMetadata = new PaginationMetadata(products.Count(), @params.Page, @params.ItemsPerPage);
        //     Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));   
            
        //     // Complete pagination 
        //     var items = await products.Skip((@params.Page -1) * @params.ItemsPerPage)
        //         .Take(@params.ItemsPerPage)
        //         .ToListAsync();
                  
        //     return Ok (items);
        // }


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
