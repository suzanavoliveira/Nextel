using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroCatalogue.Models
{
    public class SuperPower
    {
        public SuperPower()
        {
            this.SuperHero = new HashSet<SuperHero>();
        }

        [Key]
        public Int32 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SuperHero> SuperHero { get; set; }  
    }
}
