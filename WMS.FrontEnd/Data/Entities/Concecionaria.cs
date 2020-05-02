using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Data.Entities
{
    public class Concecionaria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]
        public DateTime FechaAlta { get; set; }
    }
}
