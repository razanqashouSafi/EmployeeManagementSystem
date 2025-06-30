using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyApp.Core.Helpers.Validation
{
    public static class  DataValidate
    {
        private static readonly Regex PasswordRegex = new Regex(
    @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_\-+=\[{\]};:<>|./?]).{8,}$",
    RegexOptions.Compiled);


        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                    return false;

                var domainParts = addr.Host.Split('.');
                if (domainParts.Length < 2)
                    return false;

                var tld = domainParts[^1].ToLower();
                var validTlds = new HashSet<string>
        {
            "com", "net", "org", "edu", "gov", "mil", "int",
            "info", "biz", "io", "me", "co"
        };

                return validTlds.Contains(tld);
            }
            catch
            {
                return false;
            }
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


     
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            return PasswordRegex.IsMatch(password);
        }
    }
}
