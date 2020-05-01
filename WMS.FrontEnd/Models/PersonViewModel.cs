using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<RolViewModel> Roles { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool IsEnabled { get; set; }

    }
}
