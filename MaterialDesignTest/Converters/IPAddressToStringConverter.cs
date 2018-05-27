using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DmxController.Converters
{
    public class IPAddressToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IPAddress)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IPAddress iPAddress;
            if (IPAddress.TryParse((string) value, out iPAddress))
            {
                return iPAddress;
            }
            else
            {
                return IPAddress.Any;
            }
        }
    }
}
