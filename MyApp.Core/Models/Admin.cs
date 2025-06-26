using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;

namespace MyApp.Core.Models
{
    public class Admin:MainEntity
    {
     
        public string Username { get; set; }

        [EmailAddress]
        [Display(Name = "Username")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_\-+=\[{\]};:<>|./?]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one number, and one special character.")]
        public string PasswordHash { get; set; }

        public bool IsVerified { get; set; } = false;

        public bool IsLogin { get; set; }=false;
    }
}
