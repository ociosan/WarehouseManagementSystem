using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Data
{
    public class Concecionaria
    {
        [Key]
        public int Id { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string RFC { get; set; }

        public DateTime FechaAlta { get; set; }
    }
}
