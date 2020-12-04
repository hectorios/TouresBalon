namespace SimplCommerce.Module.PaymentCreditCard.Models
{
    public class CreditCardSetting
    {
        public decimal? MinOrderValue { get; set; }

        public decimal? MaxOrderValue { get; set; }

        public decimal PaymentFee { get; set; }
    }
}
