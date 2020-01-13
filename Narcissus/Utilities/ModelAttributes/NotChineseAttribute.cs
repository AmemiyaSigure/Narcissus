using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Narcissus.Utilities.ModelAttributes
{
    public class NotChineseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string)
            {
                var str = value as string;
                if (string.IsNullOrWhiteSpace(str))
                {
                    return new ValidationResult("Empty string.");
                }

                Regex regex = new Regex(@"^\w+$");
                if (!regex.IsMatch(str))
                {
                    return new ValidationResult("Bad characters.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                throw new InvalidCastException("Invalid cast.");
            }
        }
    }
}
