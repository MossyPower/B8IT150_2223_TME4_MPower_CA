using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
namespace ProductsApi.Data;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProductsDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductsDbContext>>()))
        {
            // Look for any products.
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }
            context.Products.AddRange(
                //Sample record 1
                new Product{Title = "Honey",
                            Image="",
                            Size = "500g",
                            Category = "Condiment",
                            Price = Convert.ToDecimal(6.99),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = ""
                            },
                //Sample record 2
                new Product{Title = "Organic roasted tomoato passata", 
                            Size = "500g", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(4.49),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Fungicide = "",
                            Herbicide = "",
                            Description = "" 
                            },
                //Sample record 3
                new Product{Title = "Organic Tomatos", 
                            Size = "500g", 
                            Category = "Fruit", 
                            Price = Convert.ToDecimal(3.99),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = "" 
                            },
                //Sample record 4
                new Product{Title = "Organic Peppers", 
                            Size = "each", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(0.79),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = "" 
                            },
                //Sample record 5
                new Product{Title = "Organic strawberrys", 
                            Size = "500g", 
                            Category = "Fruit", 
                            Price = Convert.ToDecimal(2.99),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = "" 
                            },         
                //Sample record 6
                new Product{Title = "Organic Garlic", 
                            Size = "500g", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(1.49),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = "" 
                            },
                //Sample record 7
                new Product{Title = "Organic Carrots", 
                            Size = "1kg", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(3.99),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = ""
                            },
                //Sample record 8
                new Product{Title = "Organic Carrots", 
                            Size = "3kg", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(6.99),
                            Variety = "",
                            Season = "",
                            Fertiliser = "",
                            Pesticide = "",
                            Herbicide = "",
                            Fungicide = "",
                            Description = "" 
                            },
                //Sample record 9
                new Product{Title = "Organic Potatoes", 
                            Size = "2kg", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(4.99),
                            Variety = "Maris Pipers",
                            Season = "Available from March",
                            Fertiliser = "10-10-20",
                            Pesticide = "None",
                            Herbicide = "None",
                            Fungicide = "Copper Sulphate 'Bluestone' (orgainc)",
                            Description = "None" 
                            },
                //Sample record 10
                new Product{Title = "Organic Potatoes", 
                            Size = "5kg", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(7.99),
                            Variety = "Golden Wonders",
                            Season = "Available from June",
                            Fertiliser = "Fermented Seaweed",
                            Pesticide = "None",
                            Herbicide = "None",
                            Fungicide = "Copper Sulphate 'Bluestone' (orgainc)",
                            Description = "Bluestone is used to treat our potatoes to prevent blight. This is a naturaly occuring mineral meaning our potatoes are still fully organic and free from any synthetic fertilisers and pesticides" 
                            },
                //Sample record 11
                new Product{Title = "Organic charred", 
                            Size = "500g", 
                            Category = "Vegetable", 
                            Price = Convert.ToDecimal(2.99),
                            Variety = "",
                            Season = "June - August",
                            Fertiliser = "Fermented seaweed",
                            Pesticide = "None",
                            Herbicide = "None",
                            Fungicide = "None",
                            Description = "" 
                            },
                //Sample record 12
                new Product{Title = "Apple tart", 
                            Size = "500g", 
                            Category = "Baked goods", 
                            Price = Convert.ToDecimal(10.99),
                            Variety = "N/A",
                            Season = "All year",
                            Fertiliser = "N/A",
                            Pesticide = "N/A",
                            Herbicide = "N/A",
                            Fungicide = "N/A",
                            Description = "" 
                            },
                //Sample record 13
                new Product{Title = "Herbs", 
                            Size = "1x bunch", 
                            Category = "Herbs", 
                            Price = Convert.ToDecimal(0.99),
                            Variety = "TBC",
                            Season = "All year",
                            Fertiliser = "None",
                            Pesticide = "None",
                            Herbicide = "None",
                            Fungicide = "None",
                            Description = "" 
                            }
            );
            context.SaveChanges();
        }
    }
}
