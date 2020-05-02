using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class ConcecionariaViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(16,ErrorMessage = "No puede tener mas de 16 caracteres")]
        public string Clave { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "No puede tener mas de 16 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "No puede tener mas de 64 caracteres")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "No puede tener mas de 16 caracteres")]
        public string RFC { get; set; }

        [Display(Name = "Fecha Alta")]
        public DateTime FechaAlta { get; set; }
    }
}
