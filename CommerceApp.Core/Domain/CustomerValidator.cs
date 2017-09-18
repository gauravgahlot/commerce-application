using CommerceApp.Shared.Contracts;
using CommerceApp.Shared.Models;
using System;

namespace CommerceApp.Core
{
    public class CustomerValidator : ICustomerValidator
    {
        public bool ValidateCustomer(Customer customer)
        {
            Console.WriteLine("Validating customer...");
            return true;
        }
    }
}
