
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
            try
            {
                await Task.Delay(_configuration.GetValue<int>("InitialWaitTime"), stoppingToken);
                while (!stoppingToken.IsCancellationRequested)
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var factory = new ConnectionFactory { HostName = "localhost" };
                        using var connection = await factory.CreateConnectionAsync();
                        using var channel = await connection.CreateChannelAsync();

                        await channel.QueueBindAsync("CreateStudent", "CreateStudent", string.Empty);

                        var consumer = new AsyncEventingBasicConsumer(channel);
                        consumer.Received += async (model, ea) =>
                        {
                            try
                            {
                                byte[] body = ea.Body.ToArray();
                                var message = Encoding.UTF8.GetString(body);
                                await this.onReceive(message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error processing message: {ex.Message}");
                            }
                        };

                        await channel.BasicConsumeAsync(queue: "CreateStudent", autoAck: true, consumer: consumer, stoppingToken);

                        var serviceBusListenerHelper = scope.ServiceProvider.GetRequiredService<IStudentService>();
                        //await serviceBusListenerHelper.AddStudent(null);
                    }
                    await Task.Delay(_configuration.GetValue<int>("CheckUpdateTime"), stoppingToken);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private Task onReceive(string message)
        {
            return null;
        }
    }
}
