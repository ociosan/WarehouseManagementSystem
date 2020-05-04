using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class ConcecionariaVM
    {
        public int Id { get; set; }

        [Required]
        public string Clave { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string RFC { get; set; }

        public DateTime FechaAlta { get; set; }
    }
}
