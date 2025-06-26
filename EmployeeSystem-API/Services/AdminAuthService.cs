using EmployeeManagementSystem.Context;
using EmployeeSystem_API.DTOs.Request;
using EmployeeSystem_API.Helpers.Validation;
using EmployeeSystem_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Models;

namespace EmployeeSystem_API.Services
{
    public class AdminAuthService : IAdminAuth
    {


        private readonly EmployeeManagementDbContextb _context;

        public AdminAuthService(EmployeeManagementDbContextb context)
        {
            _context = context;
        }


        public async Task<string> Signup(SignupAdmnDTO input)
        {
            var errors = new List<string>();

            if (!DataValidate.IsValidEmail(input.Email))
                errors.Add("Invalid email format.");

            if (!DataValidate.IsValidPassword(input.PasswordHash))
                errors.Add("Password must be at least 8 characters long, contain at least one uppercase letter, one number, and one special character.");

            if (errors.Any())
                return string.Join("\n", errors);

            var exists = await _context.Admins.AnyAsync(a => a.Email == input.Email);
            if (exists)
                return "Email already exists.";

            var admin = new Admin
            {
                Username = input.Username,
                Email = input.Email,
                PasswordHash = HashingHelper.HashValueWith384(input.PasswordHash),
                IsVerified = true,
                IsLogin = false
            };

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return "Admin created successfully.";
        }

        public async Task<string> Login(string email, string password)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);
            if (admin == null)
                return "Invalid email or password.";

          
            var hashedInput = HashingHelper.HashValueWith384(password);

            if (hashedInput != admin.PasswordHash)
                return "Invalid email or password.";

            var token = JwtHelper.GenerateJWTToken(admin.Username, admin.Id.ToString());

            admin.IsLogin = true;
            await _context.SaveChangesAsync();

            return token;
        }









    }
}
