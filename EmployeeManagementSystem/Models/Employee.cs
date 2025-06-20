using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee: MainEntity
    {
       [MaxLength(50)]
     public string FirstName { get; set; }

      [MaxLength(50)]
      public string LastName { get; set; }

     [Required]
     [Phone]
     [RegularExpression(@"^(077|078|079|076)\d{7}$", ErrorMessage = "Phone must start with 077, 078, 079, or 076 and be 10 digits.")]
     public string PhoneNumber { get; set; }

     [Required]
     [EmailAddress]
     [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email must be a valid Gmail address.")]
        public string Email { get; set; }
      [Required]
     public decimal Salary { get; set; }

      [Required]
     public string position { get; set; }

     [DataType(DataType.Date)]
     public DateTime? HireDate { get; set; }

     public DateTime? DateOfBirth { get; set; }

     public string? profileImage { get; set; }


    

    }
}
