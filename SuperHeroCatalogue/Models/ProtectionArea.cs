using System;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroCatalogue.Models
{
    public class ProtectionArea
    {
        [Key]
        public Int32 Id { get; set; }

        public string Name { get; set; }
        
        public float Lat { get; set; }

        public float Long { get; set; }  

        public float Radius { get; set; }
    }
}
