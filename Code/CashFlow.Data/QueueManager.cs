using CashFlow.Domain.Repository;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Text;

namespace CashFlow.Data
{
    public class QueueManager : IQueueManager
    {
        private readonly string host, user, password;

        public QueueManager(string host, string user, string password)
        {
            this.host = host;
            this.user = user;
            this.password = password;
        }

        public ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = host,
                UserName = user,
                Password = password
            };
        }

        public IConnection GetConnection(ConnectionFactory connectionFactory) => connectionFactory.CreateConnection();

        public QueueDeclareOk CreateQueue(Func<IModel, QueueDeclareOk> queueDeclare, IConnection connection)
        {
            using (var channel = connection.CreateModel())
                return queueDeclare(channel);
        }

        public bool TryWriteMessageOnQueue(string message, string queueName, IConnection connection)
        {
            try
            {
                using (var channel = connection.CreateModel())
                    channel.BasicPublish(string.Empty, queueName, null, Encoding.ASCII.GetBytes(message));

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error on try write message on qeue.");
                return false;
            }
        }

        public string RetrieveSingleMessage(string queueName, IConnection connection)
        {
            BasicGetResult data;

            using (var channel = connection.CreateModel())
                data = channel.BasicGet(queueName, true);

            return data != null ? Encoding.UTF8.GetString(data.Body) : null;
        }
    }
}
