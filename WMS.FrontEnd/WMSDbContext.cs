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

        public DbSet<Concecionaria> Concecionaria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ConfiguracionGlobal> ConfiguracionGlobal { get; set; }
        public DbSet<WMS.FrontEnd.Models.ConfiguracionGlobalViewModel> ConfiguracionGlobalViewModel { get; set; }
        public DbSet<WMS.FrontEnd.Models.ConcecionariaViewModel> ConcecionariaViewModel { get; set; }
        public DbSet<WMS.FrontEnd.Models.ProductoViewModel> ProductoViewModel { get; set; }
    }
}
