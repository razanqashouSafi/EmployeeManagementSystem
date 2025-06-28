
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using MyApp.Core.Context;
using MyApp.Core.DTOs.Request;
using MyApp.Core.Interfaces;
using MyApp.Core.Services;




namespace EmployeeManagementSystem.Pages
{
    public class LoginModel : PageModel
    {


        private readonly EmployeeManagementDbContextb _context;

        private readonly IAdminAuth _AuthService;

        [BindProperty]
        public LoginReqDTO LoginInput { get; set; }


        public LoginModel(EmployeeManagementDbContextb context , IAdminAuth AuthService)
        {
            _context = context;
            _AuthService = AuthService;
          

        }
     


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _AuthService.Login(LoginInput);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.ErrorMessage);
                return Page();
            }

           
            var token = result.Token;

           

            return RedirectToPage("/Index");
        }

    }
}
