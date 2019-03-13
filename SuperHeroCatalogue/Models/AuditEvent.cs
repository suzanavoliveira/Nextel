using System;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroCatalogue.Models
{
    public class AuditEvent
    {
        [Key]
        public Int32 Id { get; set; }

        public int EntityId { get; set; }

        public string Entity { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Username { get; set; }

        public string Action { get; set; }      
    }
}
