using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagementSystem.RabbitMQConnectionFactory.Helpers.ExchangeRepositories
{
    public class CourseExchangeConfig : ExchangeConfiguration
    {
        protected override string ExchangeName => "Course_Exchange";

        protected override string ExchangeType => RabbitMQ.Client.ExchangeType.Fanout;

        public override async Task CreateExchange(IChannel channel)
        {
            await channel.ExchangeDeclareAsync(
                exchange: ExchangeName,
                type: ExchangeType,
                durable: true,
                autoDelete: false);
        }
    }
}
