using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WMS.Data.Entities
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullDescription { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
    }
}
