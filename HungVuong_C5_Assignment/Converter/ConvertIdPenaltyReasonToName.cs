using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HungVuong_C5_Assignment
{
    public class ConvertIdPenaltyReasonToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "None";

            var PenaltyReason = DatabaseFirst.Instance.db.PenaltyReasons.FirstOrDefault(i => i.Id == value.ToString());

            if (PenaltyReason == null)
                return "None";
            return PenaltyReason.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
