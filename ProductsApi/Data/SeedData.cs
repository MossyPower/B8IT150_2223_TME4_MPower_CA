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
                            Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcScowkw5jif-pq_WNieuMQxhtE4xOyVkFddQw&usqp=CAU",
                            Size = "500g",
                            Category = "Condiment",
                            Price = Convert.ToDecimal(6.99),
                            Variety = "Raw",
                            Season = "Available all year",
                            Fertiliser = "Cannot be guaranteed if free from fertiliser contaminants",
                            Pesticide = "Cannot be guaranteed if free from pesticide contaminants",
                            Herbicide = "Cannot be guaranteed if free from herbicide contaminants",
                            Fungicide = "Cannot be guaranteed if free from Fungicide contaminants",
                            Description = "Raw honey"
                            },
                //Sample record 2
                new Product{Title = "Organic roasted tomoato passata",  
                            Image = "https://images.immediate.co.uk/production/volatile/sites/2/2022/07/Passata-96cb3d2.jpg?quality=90&resize=556,505",
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
                            Image = "https://gardenary-data.s3.amazonaws.com/section-image/cNkxfUWBYhCNCs8Sf4O52Rs9CPkDjoyK1TsPbgI2.jpg",
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
                            Image = "https://seedsireland.ie/cdn/shop/products/PepperCuboOrange_1445x.png?v=1647525479",
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
                new Product{Title = "Organic Strawberries",  
                            Image = "https://www.fruithillfarm.com/media/catalog/product/cache/a83d16b6a1b667730ddb42964cf817f5/o/r/organic-strawberries.jpg",
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
                            Image = "https://www.fruithillfarm.com/media/catalog/product/cache/a83d16b6a1b667730ddb42964cf817f5/m/e/messidrome_com_651.jpg",
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
                            Image = "https://allirelandfoods.ie/wp-content/uploads/2020/08/Unknown.jpeg",
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
                            Image = "https://allirelandfoods.ie/wp-content/uploads/2020/08/Unknown.jpeg",
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
                            Image = "https://www.graigfarm.co.uk/cdn/shop/products/906_1000x.jpg?v=1616772508",
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
                            Image = "https://www.graigfarm.co.uk/cdn/shop/products/906_1000x.jpg?v=1616772508",
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
                            Image = "https://mccormackfarms.ie/wp-content/uploads/2021/06/spinachHeader.jpg",
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
                            Image = "https://www.odlums.ie/wp-content/uploads/2016/11/odlums_0012_Apple-tart.jpg",
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
                            Image = "https://theherbgarden.ie/wp-content/uploads/2019/10/fennel-cut-1024x1024.jpg",
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
