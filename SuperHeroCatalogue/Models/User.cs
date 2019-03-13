using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroCatalogue.Models
{
    public class User
    {
        [Key]
        public Int32 Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        List<Role> Roles { get; set; }
    }
}
