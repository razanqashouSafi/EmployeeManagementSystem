using MyApp.Core.Context;
using EmployeeManagementSystem.Models;
using MyApp.Core.DTOs.Request;
using MyApp.Core.DTOs.Response;
using MyApp.Core.Helpers.Validation;
using MyApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MyApp.Core.Models;

namespace MyApp.Core.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly EmployeeManagementDbContextb _context;

        public EmployeeService(EmployeeManagementDbContextb context)
        {
            _context = context;
        }

        public async Task<string> CreateEmployee(CreateEmployeeInputDTO input)
        {
            var errors = new List<string>();

            if (!DataValidate.IsValidEmail(input.Email))
                errors.Add("Invalid email format.");

            if (!DataValidate.IsValidPhoneNumber(input.PhoneNumber))
                errors.Add("Phone number must start with 077, 078, 079, or 076 and be 10 digits.");

            if (!DataValidate.IsValidSalary(input.Salary))
                errors.Add("Salary must be at least 260 JD.");

            if (!DataValidate.IsValidHireDate(input.HireDate.Value))
                errors.Add("Hire date cannot be in the future.");

            if (!DataValidate.IsValidBirthDate(input.DateOfBirth.Value))
                errors.Add("Employee must be at least 18 years old.");

            if (await _context.Employees.AnyAsync(e => e.Email == input.Email))
                errors.Add("This email already exists.");

            if (await _context.Employees.AnyAsync(e => e.PhoneNumber == input.PhoneNumber))
                errors.Add("This phone number already exists.");

            if (errors.Any())
                return string.Join("\n", errors);


            Employee employee = new Employee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Salary = input.Salary,
                Position = input.Position,
                DateOfBirth = input.DateOfBirth,
                HireDate = input.HireDate,

            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return "Employee created successfully.";
        }


        public async Task<UploadImageResult> UploadImage(int id, IFormFile profileImage)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return new UploadImageResult { Success = false, Message = $"Employee with ID {id} not found." };

            if (profileImage == null || profileImage.Length == 0)
                return new UploadImageResult { Success = false, Message = "No image was uploaded." };

            var razorWwwRoot = @"C:\Users\admin\Source\Repos\EmployeeManagementSystem\EmployeeManagementSystem\wwwroot\images";

            if (!Directory.Exists(razorWwwRoot))
                Directory.CreateDirectory(razorWwwRoot);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(profileImage.FileName);
            var filePath = Path.Combine(razorWwwRoot, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await profileImage.CopyToAsync(stream);
            }

            var relativePath = $"/images/{fileName}";

            employee.ProfileImage = relativePath;
            await _context.SaveChangesAsync();

            return new UploadImageResult
            {
                Success = true,
                Message = "Image uploaded successfully.",
                ImageUrl = relativePath
            };
        }



        public async Task<string> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return $"Employee with ID {id} not found.";

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return "Employee deleted successfully.";
        }


        public async Task<List<EmployeeDelatis>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDelatis
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    Salary = e.Salary,
                    Position = e.Position,
                    HireDate = e.HireDate,
                    DateOfBirth = e.DateOfBirth,
                    ProfileImage = e.ProfileImage
                })
                .ToListAsync();

            return employee;
        }


        public async Task<List<AllEmployeeOutputDTO>> GetAllEmployee()
        {
            var employees = await _context.Employees
                .Select(e => new AllEmployeeOutputDTO
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email
                })
                .ToListAsync();

            return employees;
        }



        public async Task<string> UpdateEmployee(UpdateEmployeeDTO input)
        {
            var employee = await _context.Employees.FindAsync(input.Id);
            if (employee == null)
                return $"Employee with ID {input.Id} not found.";


            if (!string.IsNullOrWhiteSpace(input.FirstName))
                employee.FirstName = input.FirstName;

            if (!string.IsNullOrWhiteSpace(input.LastName))
                employee.LastName = input.LastName;


            if (!string.IsNullOrWhiteSpace(input.PhoneNumber))
            {
                if (!DataValidate.IsValidPhoneNumber(input.PhoneNumber))
                    return "Invalid phone number.";
                employee.PhoneNumber = input.PhoneNumber;
            }


            if (!string.IsNullOrWhiteSpace(input.Email))
            {
                if (!DataValidate.IsValidEmail(input.Email))
                    return "Invalid email.";
                employee.Email = input.Email;
            }

            if (input.Salary.HasValue)
            {
                if (!DataValidate.IsValidSalary(input.Salary.Value))
                    return "Salary must be at least 260.";
                employee.Salary = input.Salary.Value;
            }


            if (!string.IsNullOrWhiteSpace(input.Position))
                employee.Position = input.Position;


            if (input.HireDate.HasValue)
            {
                if (!DataValidate.IsValidHireDate(input.HireDate.Value))
                    return "Hire date cannot be in the future.";
                employee.HireDate = input.HireDate.Value;
            }


            if (input.DateOfBirth.HasValue)
            {
                if (!DataValidate.IsValidBirthDate(input.DateOfBirth.Value))
                    return "Employee must be at least 18 years old.";
                employee.DateOfBirth = input.DateOfBirth.Value;
            }


            await _context.SaveChangesAsync();
            return "Employee updated successfully.";
        }



        public async Task<UploadImageResult> UpdateImageUpload(int id, IFormFile profileImage)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return new UploadImageResult
                {
                    Success = false,
                    Message = $"Employee with ID {id} not found."
                };
            }

            
            string sharedImagesPath = @"C:\Users\admin\Source\Repos\EmployeeManagementSystem\EmployeeManagementSystem\wwwroot\images";

            
            if (!string.IsNullOrEmpty(employee.ProfileImage))
            {
                var oldImagePath = Path.Combine(sharedImagesPath, Path.GetFileName(employee.ProfileImage));
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }

            if (profileImage == null || profileImage.Length == 0)
            {
                return new UploadImageResult
                {
                    Success = false,
                    Message = "No image uploaded."
                };
            }

            if (!Directory.Exists(sharedImagesPath))
                Directory.CreateDirectory(sharedImagesPath);

            var fileName = $"{Guid.NewGuid()}_{profileImage.FileName}";
            var filePath = Path.Combine(sharedImagesPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await profileImage.CopyToAsync(stream);
            }

          
            employee.ProfileImage = $"/images/{fileName}";
            await _context.SaveChangesAsync();

            return new UploadImageResult
            {
                Success = true,
                Message = "Image uploaded successfully.",
                ImageUrl = employee.ProfileImage
            };
        }
    }
    }
