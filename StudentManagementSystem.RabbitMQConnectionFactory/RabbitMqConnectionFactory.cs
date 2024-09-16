using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.RabbitMQConnectionFactory
{
    public class RabbitMqConnectionFactory
    {
        private IConnection _connection;

        public RabbitMqConnectionFactory()
        {
            CreateConnection();
        }

        private async Task CreateConnection()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            _connection = await factory.CreateConnectionAsync();
        }

        public async Task<IConnection> GetConnection()
        {
            if (_connection == null || !_connection.IsOpen)
                await CreateConnection();

            return _connection;
        }
    }
}
