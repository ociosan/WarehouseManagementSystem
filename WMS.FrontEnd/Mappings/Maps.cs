using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.FrontEnd.Data;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<ConfiguracionGlobal, ConfiguracionGlobalVM>().ReverseMap();
            CreateMap<Concecionaria, ConcecionariaVM>().ReverseMap();
            CreateMap<Producto, ProductoVM>().ReverseMap();
            CreateMap<Empleado, EmpleadoVM>().ReverseMap();
            CreateMap<IdentityRole,CreateRoleVM>().ReverseMap();
        }
    }
}
