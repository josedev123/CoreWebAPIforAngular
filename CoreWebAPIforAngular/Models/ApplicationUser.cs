using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIforAngular.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string CompanyName { get; set; }

    }
}
