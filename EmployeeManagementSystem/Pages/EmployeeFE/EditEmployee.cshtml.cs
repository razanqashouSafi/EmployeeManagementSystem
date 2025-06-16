using EmployeeManagementSystem.Context;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class EditEmployeeModel : PageModel
    {

        private readonly EmployeeManagementDbContextb context;
        public EditEmployeeModel(EmployeeManagementDbContextb context)
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
