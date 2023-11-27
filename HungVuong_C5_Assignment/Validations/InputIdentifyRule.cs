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
    public class InputIdentifyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Value is required");
            }
            if(!Regex.IsMatch(value.ToString(), @"^\d{12}$")) {
                return new ValidationResult(false, $"Value must have 12 characters, your characters: {value.ToString().Length}");
            }
            return ValidationResult.ValidResult;
        }
    }
}
