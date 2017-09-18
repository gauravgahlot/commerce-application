using CommerceApp.Shared.Models;
using System.Collections.Generic;

namespace CommerceApp.Shared.Repositories
{
    public interface IOrderRepository
    {
        List<Order> Orders();
        Order GetOrderById(int id);
    }
}
