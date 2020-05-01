using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class RolViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string FullDescription { get; set; }
        [Display(Name = "Es Administrador")]
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        [Display(Name = "Activo")]
        public bool IsEnabled { get; set; }
    }
}
