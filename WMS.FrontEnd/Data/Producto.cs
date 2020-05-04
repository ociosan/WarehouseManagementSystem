using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Data
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public DateTime? FechaAlta { get; set; }
    }
}
