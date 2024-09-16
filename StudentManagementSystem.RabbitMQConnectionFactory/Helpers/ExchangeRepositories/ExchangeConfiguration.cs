using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.RabbitMQConnectionFactory.Helpers.ExchangeRepositories
{
    public abstract class ExchangeConfiguration
    {
        protected abstract string ExchangeName { get; }

        protected abstract string ExchangeType { get; }

        public abstract Task CreateExchange(IChannel channel);
    }
}
