using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HungVuong_C5_Assignment
{
    public static class StaticValidation
    {
        public static T GetValidationRule<T>(TextBox textBox) where T : ValidationRule
        {
            BindingExpression bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            if (bindingExpression != null)
            {
                T validationRule = bindingExpression.ParentBinding.ValidationRules
                    .OfType<T>()
                    .FirstOrDefault();

                if (validationRule != null)
                {
                    ValidationResult validationResult = validationRule.Validate(textBox.Text, CultureInfo.CurrentCulture);
                    if (validationResult.IsValid == false)
                        return null;
                    return validationRule;
                }
            }

            return null;
        }
    }
}
