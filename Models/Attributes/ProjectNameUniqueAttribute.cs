using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Attributes;

public class ProjectNameUniqueAttribute : ValidationAttribute
{
    private readonly string _idPropertyName;
    public ProjectNameUniqueAttribute(string idPropertyName)
    {
        _idPropertyName = idPropertyName;
    }
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(_idPropertyName);
        if (property != null)
        {
            var idValue = property.GetValue(validationContext.ObjectInstance, null);
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext))!;
            var entity = context.Projects.SingleOrDefault(e => value != null && e.Name == value.ToString() && e.Id !=
                Int32.Parse(idValue!.ToString()!));

            if (entity != null)
            {
                if (value != null) return new ValidationResult(GetErrorMessage(value.ToString()!));
            }
        }

        return ValidationResult.Success;
    }

    private string GetErrorMessage(string name)
    {
        return $"Name {name} is already in use.";
    }
}