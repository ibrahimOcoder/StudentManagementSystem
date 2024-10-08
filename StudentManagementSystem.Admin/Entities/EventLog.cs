﻿using StudentManagementSystem.Admin.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Admin.Entities
{
    [Table("EventLog")]
    public class EventLog : EntityBase
    {
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
