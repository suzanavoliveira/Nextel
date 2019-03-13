using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroCatalogue.Models
{
    public class SuperPowerHero
    {
        public int SuperHeroId { get; set; }
        public SuperHero SuperHero { get; set; }
        public int SuperPowerId { get; set; }
        public SuperPower SuperPower { get; set; }
    }
}
