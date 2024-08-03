using StudentManagementSystem.IntegrationEventPublisher.Entities;
using StudentManagementSystem.IntegrationEventPublisher.Types;

namespace StudentManagementSystem.IntegrationEventPublisher.Repositories
{
    public interface IIntegrationEventRepository
    {
        Task<IEnumerable<EventLog>> GetUnpublishedEvents();

        Task<int> UpdateIntegrationEventLogEntryState(EventLog entry, EventLogStates state);
    }
}
