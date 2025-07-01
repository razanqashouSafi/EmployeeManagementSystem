
using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Context;
using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Core.Helpers;

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


        [BindProperty]

        public IFormFile? ProfileImageFile { get; set; }


        public List<SelectListItem> PositionOptions { get; set; }

        public IActionResult OnGet(int id)
        {

            PositionOptions = Position.Positions;
            Employee = _context.Employees.Find(id);


            if (Employee == null)
            {
                return NotFound();
            }


            return Page();


          
            }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employeeInDb = await _context.Employees.FindAsync(Employee.Id);

            if (employeeInDb == null)
            {
                return NotFound();
            }

            bool hasErrors = false;

           
            if (await _context.Employees.AnyAsync(e => e.Email == Employee.Email && e.Id != Employee.Id))
            {
                ModelState.AddModelError("Employee.Email", "Email is already in use.");
                hasErrors = true;
            }

            
            if (await _context.Employees.AnyAsync(e => e.PhoneNumber == Employee.PhoneNumber && e.Id != Employee.Id))
            {
                ModelState.AddModelError("Employee.PhoneNumber", "Phone number is already in use.");
                hasErrors = true;
            }

            if (hasErrors)
            {
                return Page(); 
            }

            
            employeeInDb.FirstName = Employee.FirstName;
            employeeInDb.LastName = Employee.LastName;
            employeeInDb.Email = Employee.Email;
            employeeInDb.PhoneNumber = Employee.PhoneNumber;
            employeeInDb.Salary = Employee.Salary;
            employeeInDb.Position = Employee.Position;
            employeeInDb.HireDate = Employee.HireDate;
            employeeInDb.DateOfBirth = Employee.DateOfBirth;

            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfileImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImageFile.CopyToAsync(stream);
                }

                employeeInDb.ProfileImage = "/images/" + fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }


    }
}
