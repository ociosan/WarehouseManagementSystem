using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.FrontEnd.Data.Entities;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Producto, ProductoViewModel>().ReverseMap();
            CreateMap<Concecionaria, ConcecionariaViewModel>().ReverseMap();
            CreateMap<ConfiguracionGlobal, ConfiguracionGlobalViewModel>().ReverseMap();
        }
    }
}
