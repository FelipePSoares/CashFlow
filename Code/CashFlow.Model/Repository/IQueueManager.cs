using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashFlow.Domain.Repository
{
    public interface IQueueManager
    {

        ConnectionFactory GetConnectionFactory();
        IConnection GetConnection(ConnectionFactory connectionFactory);
        QueueDeclareOk CreateQueue(Func<IModel, QueueDeclareOk> queueDeclare, IConnection connection);
        bool TryWriteMessageOnQueue(string message, string queueName, IConnection connection);
        string RetrieveSingleMessage(string queueName, IConnection connection);
    }
}
