using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeSystem_API.Helpers.Validation
{
    public static class  DataValidate
    {

        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   new EmailAddressAttribute().IsValid(email);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            var regex = new Regex(@"^(077|078|079|076)\d{7}$");
            return regex.IsMatch(phoneNumber);
        }

        public static bool IsValidSalary(decimal salary)
        {
            return salary >= 260;
        }

        public static bool IsValidHireDate(DateTime hireDate)
        {
            return hireDate.Date <= DateTime.UtcNow.Date;
        }

        public static bool IsValidBirthDate(DateTime birthDate)
        {
            var today = DateTime.UtcNow.Date;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
