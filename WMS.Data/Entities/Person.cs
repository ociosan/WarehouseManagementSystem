using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WMS.Data.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("Id")]
        public Rol Rol { get; set; }

        public int RolId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool IsEnabled { get; set; }
    }
}
