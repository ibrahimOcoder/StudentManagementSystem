
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StudentManagementSystem.Student.Repositories;
using System.Text;
using System.Threading;

namespace StudentManagementSystem.Student.Worker
{
    public class ServiceBusListener : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;

        public ServiceBusListener(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(_configuration.GetValue<int>("InitialWaitTime"), stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var factory = new ConnectionFactory { HostName = "localhost" };
                    using var connection = await factory.CreateConnectionAsync();
                    using var channel = await connection.CreateChannelAsync();

                    await channel.ExchangeDeclareAsync(exchange: "CreateStudent", type: ExchangeType.Fanout, durable: true);

                    var queueDeclareResult = await channel.QueueDeclareAsync(queue: "CreateStudent", durable: true);

                    if (queueDeclareResult.MessageCount > 0)
                    {
                        await channel.QueueBindAsync("CreateStudent", "CreateStudent", string.Empty);

                        var consumer = new AsyncEventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            byte[] body = ea.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            return null;
                        };

                        await channel.BasicConsumeAsync(queue: "CreateStudent", autoAck: true, consumer: consumer, stoppingToken);

                        var serviceBusListenerHelper = scope.ServiceProvider.GetRequiredService<IStudentService>();
                        //await serviceBusListenerHelper.AddStudent(null);
                    }
                }
                await Task.Delay(_configuration.GetValue<int>("CheckUpdateTime"), stoppingToken);
            }
        }
    }
}
