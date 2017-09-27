using Autofac;
using CommerceApp.Core;
using CommerceApp.Shared.Contracts;
using CommerceApp.Shared.Repositories;

namespace CommerceApp.Client
{
    public class IoCBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            // registering the dependencies with container
            builder.RegisterType<CommerceManager>();
            builder.RegisterType<CreditCardProcessor>().As<IPaymentProcessor>();
            builder.RegisterType<CustomerValidator>().As<ICustomerValidator>();
            builder.RegisterType<EmailNotifier>().As<ICustomerNotifier>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>();

            return builder.Build();
        }
    }
}
