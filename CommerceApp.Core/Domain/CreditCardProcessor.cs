using CommerceApp.Shared.Contracts;
using CommerceApp.Shared.Models;
using System;

namespace CommerceApp.Core
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(PaymentDetails payment)
        {
            Console.WriteLine("Processing payment...");
            return true;
        }
    }
}
