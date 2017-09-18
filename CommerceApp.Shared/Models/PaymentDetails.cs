namespace CommerceApp.Shared.Models
{
    public enum PaymentType
    {
        CreditCard
    }

    public class PaymentDetails
    {
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
    }
}
