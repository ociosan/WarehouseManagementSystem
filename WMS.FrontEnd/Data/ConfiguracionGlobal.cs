using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Data
{
    public class ConfiguracionGlobal
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
