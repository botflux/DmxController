using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DmxController
{
    public class ByteToDoubleConverter : IValueConverter
    {
        // byte vers double
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(System.Convert.ToInt16(System.Convert.ToByte(value)));
        }

        // double vers byte
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return System.Convert.ToByte(System.Convert.ToInt16(System.Convert.ToDouble(value)));
        }
    }
}
