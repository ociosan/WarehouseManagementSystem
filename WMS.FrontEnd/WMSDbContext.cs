using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WMS.FrontEnd.Data.Entities;
using WMS.FrontEnd.Models;

namespace WMS.Data
{
    public class WMSDbContext : IdentityDbContext
    {
        public WMSDbContext(DbContextOptions<WMSDbContext> options) : base(options)
        { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<WMS.FrontEnd.Models.RolViewModel> RolViewModel { get; set; }
    }
}
