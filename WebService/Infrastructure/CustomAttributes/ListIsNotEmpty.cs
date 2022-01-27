using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebService.Infrastructure.CustomAttributes
{
    public class ListIsNotEmpty : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            List<string> list = (List<string>)value;

            if (!list.Any())
                return new ValidationResult($"List Is Empty");


               //return base.IsValid(value, validationContext);
             
        return ValidationResult.Success;
        }
    }
}
