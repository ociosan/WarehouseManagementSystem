using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Concecionaria> Concecionarias { get; set; }
        public DbSet<ConfiguracionGlobal>  ConfiguracionesGlobales { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<WMS.FrontEnd.Models.ConfiguracionGlobalVM> ConfiguracionGlobalVM { get; set; }
        public DbSet<WMS.FrontEnd.Models.ConcecionariaVM> ConcecionariaVM { get; set; }
        public DbSet<WMS.FrontEnd.Models.ProductoVM> ProductoVM { get; set; }
        public DbSet<WMS.FrontEnd.Models.EmpleadoVM> EmpleadoVM { get; set; }
        public DbSet<WMS.FrontEnd.Models.CreateRoleVM> CreateRoleVM { get; set; }
        public DbSet<WMS.FrontEnd.Models.EditRoleVM> EditRoleVM { get; set; }
    }
}
