using System.ComponentModel.DataAnnotations;

namespace WebService.Infrastructure.CustomAttributes
{
    public class ListIsNotEmpty : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            List<string>? list = value as List<string>;

            if (!list.Any())
                return new ValidationResult($"List Is Empty");
             
        return ValidationResult.Success;
        }
    }
}
