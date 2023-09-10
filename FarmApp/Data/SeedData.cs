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
                    "At Power Family Farm, we are committed to safeguarding your privacy and ensuring the security of your personal information. This Privacy Statement outlines our practices regarding the collection, use, and protection of your data when you use our local organic food product ecommerce web application. We may collect the following types of information when you interact with our web application: Personal Information: Such as your name, email address, shipping address, and payment details when you make a purchase. Usage Information: Including your IP address, device information, and browsing history while using our website. Cookies: We may use cookies to enhance your browsing experience and gather anonymous information about your preferences. We use your information for the following purposes: Processing Orders: To fulfill your orders and deliver our products to you. Customer Support: To provide assistance and resolve any inquiries or issues you may have.  Improving Services: To enhance our web application, products, and services based on your feedback and preferences. Marketing: To send you updates, promotions, and newsletters if you opt-in to receive them. You can unsubscribe at any time. We employ industry - standard security measures to protect your data against unauthorized access, disclosure, or alteration. However, no online platform can guarantee absolute security, so please exercise caution and protect your login information.We do not sell or rent your personal information to third parties.We may share your data with trusted partners and service providers who help us operate and improve our services.You have the right to access, update, or delete your personal information. You can also opt out of marketing communications at any time. We may update this Privacy Statement from time to time to reflect changes in our practices or legal requirements.Please review it periodically. By using Power Family Farm's web application, you consent to the practices described in this Privacy Statement. If you have any questions or concerns about your privacy or this statement, please contact us. Thank you for choosing Power Family Farm. We value your trust and are committed to protecting your privacy while providing you with high-quality organic food products. Last Updated: 10/09/2023"
                    });
                context.SaveChanges();
            }
        }
    }
}