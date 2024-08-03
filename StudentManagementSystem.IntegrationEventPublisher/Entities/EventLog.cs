using StudentManagementSystem.IntegrationEventPublisher.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.IntegrationEventPublisher.Entities
{
    [Table("EventLog")]
    public class EventLog
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public EventTypes EventType { get; set; }

        [Required]
        public string EventBody { get; set; }

        [Required]
        public EventLogStates State { get; set; }

        [Required]
        public string ExchangeName { get; set; }
    }
}
