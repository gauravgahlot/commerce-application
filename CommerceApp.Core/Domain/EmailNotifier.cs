using CommerceApp.Shared.Contracts;
using System;

namespace CommerceApp.Core
{
    public class EmailNotifier : ICustomerNotifier
    {
        public string FromAddress { get; set; }
        public string SmtpServer { get; set; }

        public void NotifyCustomer(bool paymentSuccessful)
        {
            if (paymentSuccessful)
                SendPaymentSuccess();
            else
                SendPaymentFailed();
        }

        private void SendPaymentFailed()
        {
            Console.WriteLine("Notify Customer: Payment failed, order could not be placed.");
        }

        private void SendPaymentSuccess()
        {
            Console.WriteLine("Notify Customer: Payment successfull, order has been placed.");
        }
    }
}
