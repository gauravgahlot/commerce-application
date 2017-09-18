using CommerceApp.Shared.Models;

namespace CommerceApp.Shared.Contracts
{
    public interface ICustomerValidator
    {
        bool ValidateCustomer(Customer customer);
    }
}
