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
     public string PhoneNumber { get; set; }

     [Required]
     [EmailAddress]
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
