using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.Models.Validation
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
            // لا تعيّن ErrorMessage هنا حتى يسمح بالتمرير الخارجي
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of Birth is required.");

            DateTime dateOfBirth;
            try
            {
                dateOfBirth = Convert.ToDateTime(value);
            }
            catch
            {
                return new ValidationResult("Invalid Date of Birth format.");
            }

            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;

            if (age < _minAge)
            {
                // إذا تم تمرير رسالة خطأ مخصصة استعملها، وإلا استعمل الرسالة الافتراضية
                var errorMessage = string.IsNullOrEmpty(ErrorMessage)
                    ? $"Employee must be at least {_minAge} years old."
                    : ErrorMessage;

                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
