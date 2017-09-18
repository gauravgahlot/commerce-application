namespace CommerceApp.Shared.Contracts
{
    public interface ICustomerNotifier
    {
        void NotifyCustomer(bool paymentSuccessful);
        string FromAddress { get; set; }
        string SmtpServer { get; set; }
    }
}
