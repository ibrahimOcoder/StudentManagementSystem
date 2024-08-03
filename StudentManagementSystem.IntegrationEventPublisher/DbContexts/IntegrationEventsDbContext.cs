using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.IntegrationEventPublisher.Entities;
using System.Reflection;

namespace StudentManagementSystem.Admin.DbContexts
{
    public class IntegrationEventsDbContext : DbContext
    {
        public IntegrationEventsDbContext(DbContextOptions<IntegrationEventsDbContext> options) : base(options)
        {

        }

        public DbSet<EventLog> IntegrationEventLogEntries { get; set; }
    }
}
