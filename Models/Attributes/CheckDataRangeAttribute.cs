using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Attributes;

public class CheckDateRangeAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime dt = (DateTime)(value ?? throw new ArgumentNullException(nameof(value)));
        if (dt >= DateTime.Today.Date)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Make sure your date is >= than today");
    }
}