using CommerceApp.Core;
using CommerceApp.Shared.Contracts;
using CommerceApp.Shared.Models;
using CommerceApp.Shared.Repositories;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Tests
{
    [TestFixture]
    public class CommerceManagerTests
    {
        private ILogger _logger;
        private ICustomerValidator _customerValidator;
        private IPaymentProcessor _paymentProcessor;
        private ICustomerNotifier _customerNotifier;
        private IStoreRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _logger = Substitute.For<ILogger>();
            _customerValidator = Substitute.For<ICustomerValidator>();
            _customerNotifier = Substitute.For<ICustomerNotifier>();
            _paymentProcessor = Substitute.For<IPaymentProcessor>();
            _repository = Substitute.For<IStoreRepository>();
        }

        [Test]
        public void WhenOrderIsProcessed_CustomerIsNotified()
        {
            // arrange
            var order = GetDummyOrder();
            var manager = new CommerceManager(_repository, 
                _customerValidator, _paymentProcessor, 
                _customerNotifier, _logger);

            _customerValidator.ValidateCustomer(Arg.Any<Customer>()).Returns(true);
            _paymentProcessor.ProcessPayment(Arg.Any<PaymentDetails>()).Returns(true);

            // act
            manager.ProcessOrder(order);

            // assert
            Assert.AreEqual(1, _customerNotifier.ReceivedCalls().Count());
        }

        private Order GetDummyOrder()
        {
            return new Order
            {
                Id = 1,
                Customer = new Customer { Name = "Allen" },
                LineItems = new List<Product>
                    {
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
                    Amount = 2000,
                    CardNumber = "0123456789"
                },
                Date = DateTime.Now
            };
        }
    }
}