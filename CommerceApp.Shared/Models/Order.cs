using System;
using System.Collections.Generic;

namespace CommerceApp.Shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> LineItems { get; set; }
        public Customer Customer { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public DateTime Date { get; set; }
    }
}
