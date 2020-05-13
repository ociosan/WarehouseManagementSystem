using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd.Models
{
    public class CreateRoleVM
    {
        public string Id { get; set; }

        [Display(Name = "Descripción")]
        public string Name { get; set; }
    }

    public class EditRoleVM
    {
        public string Id { get; set; }

        [Display(Name = "Descripción")]
        public string Name { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}


