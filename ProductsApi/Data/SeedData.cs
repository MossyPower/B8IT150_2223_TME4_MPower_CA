using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
namespace ProductsApi.Data;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProductsDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductsDbContext>>()))
        {
            // Look for any movies.
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }
            context.Products.AddRange(
                new Product{ Title = "Honey", Size = "500g", Category = "Condiment", Price = Convert.ToDecimal(6.99) },
                new Product{ Title = "Organic roasted tomoato passata", Size = "500g", Category = "Vegtable", Price = Convert.ToDecimal(4.49) },
                new Product{ Title = "Organic Tomatos", Size = "500g", Category = "Vegtable", Price = Convert.ToDecimal(3.99) },
                new Product{ Title = "Organic Peppers", Size = "each", Category = "Vegtable", Price = Convert.ToDecimal(0.79) },
                new Product{ Title = "Organic strawberrys", Size = "500g", Category = "Vegtable", Price = Convert.ToDecimal(2.99) },         
                new Product{ Title = "Organic Garlic", Size = "500g", Category = "Vegtable", Price = Convert.ToDecimal(1.49) },
                new Product{ Title = "Organic Carrots", Size = "1kg", Category = "Vegtable", Price = Convert.ToDecimal(3.99) },
                new Product{ Title = "Organic Carrots", Size = "3kg", Category = "Vegtable", Price = Convert.ToDecimal(6.99) },
                new Product{ Title = "Organic Potatoes", Size = "2kg", Category = "Vegtable", Price = Convert.ToDecimal(4.99) },
                new Product{ Title = "Organic Potatoes", Size = "5kg", Category = "Vegtable", Price = Convert.ToDecimal(7.99) },
                new Product{ Title = "Organic charred", Size = "500g", Category = "Vegtable", Price = Convert.ToDecimal(2.99) },
                new Product{ Title = "Apple tart", Size = "500g", Category = "Baked goods", Price = Convert.ToDecimal(10.99) },
                new Product{ Title = "Herbs", Size = "1x bunch", Category = "Herbs", Price = Convert.ToDecimal(0.99) }
            );
            context.SaveChanges();
        }
    }
}