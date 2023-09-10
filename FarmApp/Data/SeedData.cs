using Microsoft.EntityFrameworkCore;
using FarmApp.Models;

namespace FarmApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products.
                if (context.PrivacyModel.Any())
                {
                    return; // DB has been seeded
                }
                context.PrivacyModel.AddRange(
                    //Sample Description
                    new PrivacyModel{Description =
                    "Enter you privacy statement here"
                    });
                context.SaveChanges();
            }
        }
    }
}