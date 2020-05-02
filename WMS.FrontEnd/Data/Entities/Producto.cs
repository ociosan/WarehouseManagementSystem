using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Data.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "No puede tener mas de 16 caracteres")]
        public string Codigo { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "No puede tener mas de 64 caracteres")]
        public string Descripcion { get; set; }

        [RegularExpression(@"^(0|-?\d{0,10}(\.\d{0,2})?)$", ErrorMessage = "Precio no válido, máximo 2 decimales.")]
        [Range(0, 9999999999.99, ErrorMessage = "Debe de ser 10 digitos con 2 decimales")]
        [Required]
        public decimal? Precio { get; set; }

        [Required]
        public DateTime? FechaAlta { get; set; }
    }
}
