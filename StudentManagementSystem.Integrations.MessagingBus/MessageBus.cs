using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StudentManagementSystem.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Integrations.MessagingBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IConfiguration configuration;

        public MessageBus(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task PublishMessage(IntegrationBaseMessage message, string exchangeName)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout, durable: true);

            var jsonMessage = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(jsonMessage);

            await channel.BasicPublishAsync(exchangeName, "", body);

            var queueName = await channel.QueueDeclareAsync(queue: "CreateStudent", durable: true);

            await channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: string.Empty);
        }
    }
}
