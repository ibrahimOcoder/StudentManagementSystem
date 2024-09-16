using Newtonsoft.Json;
using StudentManagementSystem.CommunicationConfigs;
using StudentManagementSystem.IntegrationEventPublisher.Repositories;
using StudentManagementSystem.IntegrationEventPublisher.Types;
using StudentManagementSystem.Integrations.MessagingBus;
using System.Configuration;

namespace StudentManagementSystem.IntegrationEventPublisher.Worker
{
    public class EventPublisher : BackgroundService
    {
        private readonly ILogger<EventPublisher> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMessageBus _messageBus;
        private readonly IIntegrationEventRepository _iIntegrationEventRepository;

        public EventPublisher(ILoggerFactory loggerFactory, IConfiguration configuration, IMessageBus messageBus, IIntegrationEventRepository iIntegrationEventRepository)
        {
            _logger = loggerFactory.CreateLogger<EventPublisher>();
            _configuration = configuration;
            _messageBus = messageBus;
            _iIntegrationEventRepository = iIntegrationEventRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("EventPublisher is starting.");

            stoppingToken.Register(() => _logger.LogDebug("EventPublisher background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("EventPublisher background task is doing background work.");

                await CheckEventsForPublishing();

                await Task.Delay(_configuration.GetValue<int>("CheckUpdateTime"), stoppingToken);
            }

            _logger.LogDebug("EventPublisher background task is stopping.");

            await Task.CompletedTask;
        }

        private async Task CheckEventsForPublishing()
        {
            _logger.LogDebug("Checking for unpublished events");

            var unpublishedEvents = await _iIntegrationEventRepository.GetUnpublishedEvents();

            foreach (var eventToPublish in unpublishedEvents)
            {
                _logger.LogInformation("----- Publishing integration event: {Id} to Exchange Name: {ExchangeName}", eventToPublish.Id, eventToPublish.ExchangeName);
                try
                {
                    var message = JsonConvert.DeserializeObject<IntegrationBaseMessage>(eventToPublish.EventBody);

                    await _iIntegrationEventRepository.UpdateIntegrationEventLogEntryState(eventToPublish, EventLogStates.In_Process);

                    await _messageBus.PublishMessage(message, eventToPublish.ExchangeName);

                    await _iIntegrationEventRepository.UpdateIntegrationEventLogEntryState(eventToPublish, EventLogStates.Published);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("----- Error publishing integration event: {IntegrationEventId}.  Exception:{ex}", eventToPublish.EventBody, ex.ToString());
                }
            }
        }
    }
}
