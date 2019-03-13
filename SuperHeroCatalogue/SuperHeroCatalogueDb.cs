using Microsoft.EntityFrameworkCore;
using SuperHeroCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroCatalogue
{
    public class SuperHeroCatalogueDb : DbContext
    {
        public SuperHeroCatalogueDb(DbContextOptions options) : base(options) { }

        public DbSet<AuditEvent> AuditEvents { get; set; }
        public DbSet<ProtectionArea> ProtectionAreas { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
