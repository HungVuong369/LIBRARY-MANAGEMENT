using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HungVuong_C5_Assignment
{
    public class ParentIDToParentName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            FunctionViewModel _FunctionVM = new FunctionViewModel();
            Function function = _FunctionVM.functionRepo.Items.Find(i => i.Id == value.ToString());
            if (function == null)
                return null;
            return function.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
