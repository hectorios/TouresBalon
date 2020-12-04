using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentCreditCard.Data
{
    public class PaymentCreditCardCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("CreditCard") { Name = "Credit Card", LandingViewComponentName = "CreditCardLanding", ConfigureUrl = "payments-creditcard-config", IsEnabled = true, AdditionalSettings = null }
            );
        }
    }
}
