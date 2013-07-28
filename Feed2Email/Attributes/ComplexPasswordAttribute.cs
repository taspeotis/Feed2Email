using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Feed2Email.Attributes
{
    /// <remarks>
    /// If we need client-side validation we might replace this with some nasty regex.
    /// </remarks>
    public class ComplexPasswordAttribute : ValidationAttribute
    {
        public ComplexPasswordAttribute()
            : this ("The {0} field does not meet complexity requirements")
        {}

        public ComplexPasswordAttribute(string errorMessage)
            : base (() => errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            var password = value as string;

            return password != null &&
                   password.Length >= 7 &&
                   password.Any(Char.IsUpper) &&
                   password.Any(Char.IsLower) &&
                   password.Any(Char.IsDigit);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return IsValid(value) ? null : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}