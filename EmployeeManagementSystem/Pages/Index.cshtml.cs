using EmployeeManagementSystem.Context;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
    }
}
