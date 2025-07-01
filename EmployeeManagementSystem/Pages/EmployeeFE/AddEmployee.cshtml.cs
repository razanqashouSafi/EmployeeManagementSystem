
using MyApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Helpers;
using MyApp.Core.Context;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EmployeeManagementSystem.Pages.EmployeeFE
{
    public class AddEmployeeModel : PageModel
    {

        private readonly EmployeeManagementDbContextb _context;

        public List<SelectListItem> PositionOptions { get; set; }


        public AddEmployeeModel(EmployeeManagementDbContextb context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }


        [BindProperty]

        public IFormFile? ProfileImageFile { get; set; }
        public void OnGet()
        {
            PositionOptions = Position.Positions;
      


        }


        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();  
        //    }

        //    Employee.CreateDate = DateTime.Now;

        //    _context.Employees.Add(Employee);

        //    _context.SaveChanges();



        //    return RedirectToPage("/Index"); 

        //}


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool hasErrors = false;

            if (await _context.Employees.AnyAsync(e => e.Email == Employee.Email))
            {
                ModelState.AddModelError("Employee.Email", "Email is already in use.");
                hasErrors = true;
            }

            if (await _context.Employees.AnyAsync(e => e.PhoneNumber == Employee.PhoneNumber))
            {
                ModelState.AddModelError("Employee.PhoneNumber", "Phone number is already in use.");
                hasErrors = true;
            }

            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/bmp", "image/webp" };

                if (!allowedContentTypes.Contains(ProfileImageFile.ContentType.ToLower()))
                {
                    ModelState.AddModelError("ProfileImageFile", "Only image files (jpg, png, gif, bmp, webp) are allowed.");
                    hasErrors = true;
                }
            }

            if (hasErrors)
            {
                return Page(); 
            }

            if (ProfileImageFile != null && ProfileImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfileImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImageFile.CopyToAsync(stream);
                }

                Employee.ProfileImage = "/images/" + fileName;
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
    }
