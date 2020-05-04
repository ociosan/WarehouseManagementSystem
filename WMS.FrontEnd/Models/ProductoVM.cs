using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class ProductoVM
    {
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }
    }
}
