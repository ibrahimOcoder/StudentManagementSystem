using StudentManagementSystem.Admin.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Admin.Entities
{
    [Table("EventLog")]
    public class EventLog : EntityBase
    {
        public EventTypes EventType { get; set; }

        public string EventBody { get; set; }

        public EventLogStates State { get; set; }
    }
}
