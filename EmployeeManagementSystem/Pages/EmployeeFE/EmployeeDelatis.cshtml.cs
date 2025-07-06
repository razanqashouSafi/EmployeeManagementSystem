
using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Core.Context;
using MyApp.Core.Models;
using MyApp.Core.Services;
using MyApp.Core.Interfaces;
using MyApp.Core.DTOs.Response;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class EmployeeDelatisModel : PageModel
    {
        private readonly IEmployee _employeeService;

        public EmployeeDelatisModel(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        public EmployeeDelatis Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _employeeService.GetEmployee(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
