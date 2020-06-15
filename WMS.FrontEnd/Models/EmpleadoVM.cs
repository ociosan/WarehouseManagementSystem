using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class EmpleadoVM
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class CreateEmpleadoVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Ingresa el nombre del empleado")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Ingresa los apellidos del usuario")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Selecciona la fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        public string FechaAlta { get; set; }
        [Required(ErrorMessage = "Ingresa una cuenta de correo electrónico")]
        [EmailAddress(ErrorMessage = "Cuenta de correo Inválido")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Perfil:")]
        public string NombreRol { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }

    public class DisplayEmpleadoVM
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }
        [Display(Name = "Perfil")]
        public string NombreRol { get; set; }

    }

}
