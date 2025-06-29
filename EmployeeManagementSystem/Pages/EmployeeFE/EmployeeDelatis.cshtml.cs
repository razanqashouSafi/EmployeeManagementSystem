
using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Core.Context;
using MyApp.Core.Models;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class EmployeeDelatisModel : PageModel
    {
        private readonly EmployeeManagementDbContextb _context;

        public EmployeeDelatisModel(EmployeeManagementDbContextb context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
