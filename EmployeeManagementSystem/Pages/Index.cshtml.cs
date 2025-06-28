
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Context;
using MyApp.Core.Models;

namespace EmployeeManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeManagementDbContextb _context;

        public IndexModel(ILogger<IndexModel> logger, EmployeeManagementDbContextb context)
        {
            _logger = logger;
            _context = context;
        }


      
        public List<Employee> Employees { get; set; }
        public async Task OnGetAsync()
        {
          
            Employees = await _context.Employees.ToListAsync();
        }


        public  IActionResult OnPostDelete(int id)
        {
            var employee=_context.Employees.Find( id);
            if (employee != null)
            {
               _context.Employees.Remove(employee);
              _context.SaveChanges();

            }

            return RedirectToPage("/Index");
        }
    }
}
