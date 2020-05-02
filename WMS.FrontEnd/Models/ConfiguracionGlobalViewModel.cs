using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class ConfiguracionGlobalViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "No puede tener mas de 32 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "No puede tener mas de 256 caracteres")]
        public string Valor { get; set; }
    }
}
