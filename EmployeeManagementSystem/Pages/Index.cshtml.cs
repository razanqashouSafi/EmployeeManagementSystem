
using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Context;
using MyApp.Core.Models;
using MyApp.Core.Interfaces;
using MyApp.Core.DTOs.Response;

namespace EmployeeManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeManagementDbContextb _context;
        private readonly IEmployee _employeeService;
        public IndexModel(ILogger<IndexModel> logger, IEmployee employeeService)
        {
            _logger = logger;
         
            _employeeService = employeeService;
        }


      
        public List<AllEmployeeOutputDTO> Employees { get; set; } = new();



        public async Task OnGetAsync()
        {

            Employees = await _employeeService.GetAllEmployee();
        }


        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            if (!result.Contains("success"))
            {
                ModelState.AddModelError(string.Empty, result);
                return Page();
            }

            return RedirectToPage("/Index");
        }

    }
}
