using CommerceApp.Shared.Contracts;
using System;

namespace CommerceApp.Core
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"{message} Timestamp: {DateTime.Now}.");
        }
    }
}
