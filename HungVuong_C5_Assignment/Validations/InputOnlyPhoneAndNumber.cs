using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class InputOnlyPhoneAndNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Value is required");
            }

            if (Regex.IsMatch(value.ToString(), @"^\d+$"))
            {
                return new ValidationResult(false, $"Please enter letters");
            }
            return ValidationResult.ValidResult;
        }
    }
}
