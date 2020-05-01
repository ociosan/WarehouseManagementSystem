using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WMS.Data.Entities;

namespace WMS.Data
{
    public class WMSDbContext : IdentityDbContext
    {
        public WMSDbContext(DbContextOptions<WMSDbContext> options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Rol> Rols { get; set; }
    }
}
