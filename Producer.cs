using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Booking
{
    public class Producer
    {
        private readonly string _queueName;
        private readonly string _hostName;

        public Producer(string queueName, string hostName)
        {
            _queueName = queueName;
            _hostName = "shark.rmq.cloudamqp.com";
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory()
            {
                _hostName = _hostName,
                Port = 5672,
                UserName = "xgdjjs",
                Password = "bkjp:IHJLMu;oijIUpoj-Hvt56mk",
                VirtualHost = "chrjkil"

            };
            using var connection = factory.CreateConnection();
            using var channel:IModel = connection.CreateModel();

            channel.ExchangeDeclare(
                "direct_exchange",
                Type:"direct",
                durable:false,
                autoDelete:false
                arguments:null
                );

            var body:byte[] = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "direct_exchange",
                routingKey: _queueName,
                basicProperties: null,
                body: body);
        }
    }
}
