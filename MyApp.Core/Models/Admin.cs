using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Models;

namespace MyApp.Core.Models
{
    public class Admin:MainEntity
    {
     

        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
       
        public string PasswordHash { get; set; }

        public bool IsVerified { get; set; } = false;

        public bool IsLogin { get; set; }=false;
    }
}
