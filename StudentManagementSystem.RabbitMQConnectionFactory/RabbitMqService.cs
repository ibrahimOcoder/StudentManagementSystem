using RabbitMQ.Client;
using StudentManagementSystem.RabbitMQConnectionFactory.Helpers.ExchangeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace StudentManagementSystem.RabbitMQConnectionFactory
{
    public class RabbitMqService : IDisposable
    {
        private readonly RabbitMqConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        public RabbitMqService(RabbitMqConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.GetConnection().Result;
            _channel = _connection.CreateChannelAsync().Result;

            Initialize();
        }

        private async Task Initialize()
        {
            var studentExchange = new StudentExchangeConfig();
            await studentExchange.CreateExchange(this._channel);


            var courseExchange = new CourseExchangeConfig();
            await courseExchange.CreateExchange(this._channel);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
