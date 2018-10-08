using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api
{
    internal static class Constants
    {
        internal static class QueueManager
        {
            public static readonly string Host = "RabbitMQ:host";
            public static readonly string User = "RabbitMQ:user";
            public static readonly string Password = "RabbitMQ:password";
        }
    }
}
