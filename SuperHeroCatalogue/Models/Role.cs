using System;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroCatalogue.Models
{
    public class Role
    {
        [Key]
        public Int32 Id { get; set; }

        public string Name { get; set; }
    }
}
