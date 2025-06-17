using EmployeeManagementSystem.Context;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class AddEmployeeModel : PageModel
    {

        private readonly EmployeeManagementDbContextb _context;
        public AddEmployeeModel(EmployeeManagementDbContextb context)
        {
           _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();  
            }

            Employee.CreateDate = DateTime.Now;

            _context.Employees.Add(Employee);
            _context.SaveChanges();

            return RedirectToPage("/Index"); 
        }
    }
}
