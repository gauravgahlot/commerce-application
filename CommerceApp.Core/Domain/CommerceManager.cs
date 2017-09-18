using CommerceApp.Shared.Contracts;
using CommerceApp.Shared.Models;
using CommerceApp.Shared.Repositories;

namespace CommerceApp.Core
{
    public class CommerceManager
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICustomerValidator _customerValidator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ICustomerNotifier _customerNotifier;
        private readonly ILogger _logger;

        public CommerceManager(IStoreRepository storeRepository,
            ICustomerValidator customerValidator,
            IPaymentProcessor paymentProcessor,
            ICustomerNotifier customerNotifier,
            ILogger logger)
        {
            _storeRepository = storeRepository;
            _paymentProcessor = paymentProcessor;
            _customerNotifier = customerNotifier;
            _customerValidator = customerValidator;
            _logger = logger;
        }

        public bool ProcessOrder(Order order)
        {
            var paymentStatus = false;
            if (_customerValidator.ValidateCustomer(order.Customer))
            {
                foreach(var lineItem in order.LineItems)
                {
                    // updating store inventory
                    _storeRepository.UpdateInventoryForProduct(lineItem);
                }

                // processing the order payment
                paymentStatus = _paymentProcessor.ProcessPayment(order.PaymentDetails);

                // log if order processing fails
                if (!paymentStatus)
                    _logger.Log($"Order with Order_Id: {order.Id} could not be placed.");

                // notifying the customer for order status
                _customerNotifier.NotifyCustomer(paymentStatus);
            }
            return paymentStatus;
        }
    }
}
