using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementSystem.Admin.DbContexts;
using StudentManagementSystem.IntegrationEventPublisher.Repositories;
using StudentManagementSystem.IntegrationEventPublisher.Services;
using StudentManagementSystem.IntegrationEventPublisher.Worker;
using StudentManagementSystem.Integrations.MessagingBus;
using System.Configuration;

namespace StudentManagementSystem.IntegrationEventPublisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            var optionsBuilder = new DbContextOptionsBuilder<IntegrationEventsDbContext>();
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("AdminDbConnection"),
                options => options.EnableRetryOnFailure(
                                                            maxRetryCount: 5,
                                                            maxRetryDelay: TimeSpan.FromSeconds(30),
                                                            errorNumbersToAdd: null
                                                       ));

            builder.Services.AddSingleton<IMessageBus, MessageBus>();

            builder.Services.AddSingleton<IIntegrationEventRepository>(new IntegrationEventRepository(optionsBuilder.Options));

            builder.Services.AddHostedService<EventPublisher>();

            var host = builder.Build();
            host.Run();
        }
    }
}