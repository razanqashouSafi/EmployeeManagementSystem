using EmployeeManagementSystem.Context;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class AddEmployeeModel : PageModel
    {

        private readonly EmployeeManagementDbContextb context;
        public AddEmployeeModel(EmployeeManagementDbContextb context)
        {
            this.context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public void OnGet()
        {
        }
    }
}
