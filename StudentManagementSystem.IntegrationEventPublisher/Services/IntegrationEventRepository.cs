using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StudentManagementSystem.Admin.DbContexts;
using StudentManagementSystem.IntegrationEventPublisher.Entities;
using StudentManagementSystem.IntegrationEventPublisher.Repositories;
using StudentManagementSystem.IntegrationEventPublisher.Types;

namespace StudentManagementSystem.IntegrationEventPublisher.Services
{
    public class IntegrationEventRepository : IIntegrationEventRepository
    {
        private readonly DbContextOptions<IntegrationEventsDbContext> dbContextOptions;

        public IntegrationEventRepository(DbContextOptions<IntegrationEventsDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task<IEnumerable<EventLog>> GetUnpublishedEvents()
        {
            await using var _dbContext = new IntegrationEventsDbContext(dbContextOptions);
            return await _dbContext.IntegrationEventLogEntries.Where(e => e.State == EventLogStates.Pending).ToListAsync();
        }

        public async Task<int> UpdateIntegrationEventLogEntryState(EventLog entry, EventLogStates state)
        {
            await using var _dbContext = new IntegrationEventsDbContext(dbContextOptions);
            var entryInDatabase = await _dbContext.IntegrationEventLogEntries.Where(e => e.Id == entry.Id).FirstOrDefaultAsync();
            if (entryInDatabase is not null)
            {
                entryInDatabase.State = state;
                return await _dbContext.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
