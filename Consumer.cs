using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging
{
    public class Consumer : IDisposable
    {
        private readonly string _queueName;
        private readonly string _hostName;

        private readonly IConnection connection;
        private readonly IModel _channel;

        public Consumer(string queueName, string hostName)
        {
            _queueName = queueName;
            _hostName = "shark.rmq.cloudamqp.com";
            var factory = new ConnectionFactory()
            {
                _hostName = _hostName,
                Port = 5672,
                UserName = "xgdjjs",
                Password = "bkjp:IHJLMu;oijIUpoj-Hvt56mk",
                VirtualHost = "chrjkil"

            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Receive (EventHandler<BasicDeliverEventArgs> receiveCallback)
        {
            _channel.ExchangeDeclare(exchange: "direct_exchange",
                Type: "direct");

            _channel.QueueDeclare(Queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.QueueBind(Queue: _queueName,
                exchange: "direct_exchange",
                routingKey: _queueName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += receiveCallback;

            _channel.BasicConsume(Queue: _queueName, autoAck: true, consumer: consumer);
        }

        public void Dispose()
        {
            _connction?.Dispose();
            _channel?.Dispose();
        }
    }
}
