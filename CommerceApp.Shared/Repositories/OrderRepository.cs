using CommerceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommerceApp.Shared.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders;

        public OrderRepository()
        {
            Initialize();
        }

        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> Orders()
        {
            return _orders;
        }

        private void Initialize()
        {
            _orders = new List<Order> {
                new Order
                {
                    Id = 1,
                    Customer = new Customer { Name = "Mark" },
                    LineItems = new List<Product>
                    {
                        new Product
                        {
                            Id = 101,
                            Name = "iPhone",
                            Quantity = 1,
                            UnitPrice = 200
                        },
                        new Product
                        {
                            Id = 102,
                            Name = "iPad",
                            Quantity = 1,
                            UnitPrice = 800
                        },
                        new Product
                        {
                            Id = 103,
                            Name = "MacBook Pro",
                            Quantity = 1,
                            UnitPrice = 2000
                        }
                    },
                    PaymentDetails = new PaymentDetails
                    {
                        PaymentType = PaymentType.CreditCard,
                        Amount = 3000,
                        CardNumber = "0123456789"
                    },
                    Date = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    Customer = new Customer { Name = "Bryan" },
                    LineItems = new List<Product>
                    {
                        new Product
                        {
                            Id = 101,
                            Name = "iPhone",
                            Quantity = 1,
                            UnitPrice = 200
                        },
                        new Product
                        {
                            Id = 104,
                            Name = "Dell XPS",
                            Quantity = 1,
                            UnitPrice = 1800
                        }
                    },
                    PaymentDetails = new PaymentDetails
                    {
                        PaymentType = PaymentType.CreditCard,
                        Amount = 2000,
                        CardNumber = "0123456789"
                    },
                    Date = DateTime.Now
                }
            };
        }
    }
}
