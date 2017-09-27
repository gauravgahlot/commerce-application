using Autofac;
using CommerceApp.Core;
using CommerceApp.Shared.Repositories;
using System.Linq;

namespace CommerceApp.Client
{
    class Program
    {
        static void Main()
        {
            // consuming the CommerceApp Core
            var order = new OrderRepository().Orders().First();

            // buuilding the container to resolve the CommerceManager
            IContainer container = IoCBuilder.Build();
            var app = container.Resolve<CommerceManager>();

            app.ProcessOrder(order);

            System.Console.ReadKey();
        }
    }
}
