using System.ComponentModel.DataAnnotations;
using EmployeeManagementSystem.Models.Validation;


namespace EmployeeManagementSystem.Models
{
    public class Employee: MainEntity
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^(077|078|079|076)\d{7}$", ErrorMessage = "Phone must start with 077, 078, 079, or 076 and be 10 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(260, double.MaxValue, ErrorMessage = "Salary must be at least 260 JD.")]
        [Display(Name = "Salary (JD)")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [DataType(DataType.Date)]
        [NotFutureDate(ErrorMessage = "Hire date cannot be in the future.")]
        [Display(Name = "Hire Date")]
        [Required]
        public DateTime? HireDate { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [MinAge(18)]
        public DateTime? DateOfBirth { get; set; }
        


        [Display(Name = "Profile Image")]
     
        public string? ProfileImage { get; set; }
    }
}
