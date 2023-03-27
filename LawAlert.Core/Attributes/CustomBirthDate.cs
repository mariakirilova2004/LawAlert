using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Infrastructure.Attributes
{
    public class CustomBirthDate
    {
        public class CustomBirthDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                // This assumes inclusivity, i.e. exactly six years ago is okay
                if ((DateTime.Now.AddYears(-100).CompareTo(value) <= 0 && DateTime.Now.AddYears(-14).CompareTo(value) <= 0))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Enter valid birth date");
                }
            }
        }
    }
}
