using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Context;
using MyApp.Core.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class ManageEmployeeModel : PageModel
    {
        private readonly EmployeeManagementDbContextb _context;

        public ManageEmployeeModel(EmployeeManagementDbContextb context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile? ProfileImageFile { get; set; }

        public List<SelectListItem> PositionOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PositionOptions = Position.Positions;

            if (id.HasValue)
            {
               
                Employee = await _context.Employees.FindAsync(id.Value);
                if (Employee == null)
                    return NotFound();
            }
            else
            {

                Employee = new Employee();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            PositionOptions = Position.Positions;

            if (!ModelState.IsValid)
                return Page();

            bool hasErrors = false;

            if (await _context.Employees.AnyAsync(e => e.Email == Employee.Email && e.Id != id))
            {
                ModelState.AddModelError("Employee.Email", "Email is already in use.");
                hasErrors = true;
            }

            if (await _context.Employees.AnyAsync(e => e.PhoneNumber == Employee.PhoneNumber && e.Id != id))
            {
                ModelState.AddModelError("Employee.PhoneNumber", "Phone number is already in use.");
                hasErrors = true;
            }

            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/bmp", "image/webp" };
                if (!allowedContentTypes.Contains(ProfileImageFile.ContentType.ToLower()))
                {
                    ModelState.AddModelError("ProfileImageFile", "Only image files are allowed.");
                    hasErrors = true;
                }
            }

            if (hasErrors)
                return Page();

            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ProfileImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImageFile.CopyToAsync(stream);
                }

                Employee.ProfileImage = "/images/" + fileName;
            }

            if (id.HasValue)
            {
                // Update
                var existing = await _context.Employees.FindAsync(id.Value);
                if (existing == null)
                    return NotFound();

                existing.FirstName = Employee.FirstName;
                existing.LastName = Employee.LastName;
                existing.Email = Employee.Email;
                existing.PhoneNumber = Employee.PhoneNumber;
                existing.Salary = Employee.Salary;
                existing.Position = Employee.Position;
                existing.HireDate = Employee.HireDate;
                existing.DateOfBirth = Employee.DateOfBirth;

                if (Employee.ProfileImage != null)
                    existing.ProfileImage = Employee.ProfileImage;

                _context.Employees.Update(existing);
            }
            else
            {
                // Add
                _context.Employees.Add(Employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
