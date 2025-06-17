using EmployeeManagementSystem.Context;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class EditEmployeeModel : PageModel
    {

        private readonly EmployeeManagementDbContextb _context;
        public EditEmployeeModel(EmployeeManagementDbContextb context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        private void OnGet()
        {
        }





    
        public IActionResult OnGet(int id)
        {
            Employee = _context.Employees.Find(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var employeeInDb = _context.Employees.Find(Employee.Id);
                if (employeeInDb == null)
                {
                    return NotFound();
                }

                employeeInDb.FirstName = Employee.FirstName;
                employeeInDb.LastName = Employee.LastName;
                employeeInDb.Email = Employee.Email;
                employeeInDb.PhoneNumber = Employee.PhoneNumber;
                employeeInDb.Salary = Employee.Salary;
                employeeInDb.position = Employee.position;
                employeeInDb.HireDate = Employee.HireDate;
                employeeInDb.DateOfBirth = Employee.DateOfBirth;
                employeeInDb.profileImage = Employee.profileImage;

                _context.SaveChanges();

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error saving to database: " + ex.Message);
                return Page();
            }
        }


    }
}
