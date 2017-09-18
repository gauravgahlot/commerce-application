using CommerceApp.Shared.Models;

namespace CommerceApp.Shared.Contracts
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(PaymentDetails payment);
    }
}
