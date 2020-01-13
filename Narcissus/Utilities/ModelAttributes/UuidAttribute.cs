using System;
using System.ComponentModel.DataAnnotations;

namespace Narcissus.Utilities.ModelAttributes
{
    public class UuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string)
            {
                var uuid = value as string;
                if (Guid.TryParse(uuid, out _))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("It is not a UUID.");
                }
            }
            else
            {
                throw new InvalidCastException("Invalid cast.");
            }
        }
    }
}
