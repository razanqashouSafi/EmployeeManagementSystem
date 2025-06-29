using System.ComponentModel.DataAnnotations;

namespace MyApp.Core.Models.Validation
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is DateTime dateValue)
            {
                if (dateValue.Date <= DateTime.Today)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} cannot be a future date.");
                }
            }

            return new ValidationResult("Invalid date format.");
        }
    
    }
}
