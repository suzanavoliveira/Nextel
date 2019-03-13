using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroCatalogue.Models
{
    public class SuperHero
    {
        public SuperHero() {
            this.SuperPowers = new HashSet<SuperPower>();
        }

        [Key]
        public Int32 Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public ProtectionArea ProtectionArea { get; set; }

        public virtual ICollection<SuperPower> SuperPowers { get; set; }

    }
}
