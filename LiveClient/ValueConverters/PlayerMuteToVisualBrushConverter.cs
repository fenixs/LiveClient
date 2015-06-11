using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace LiveClient.ValueConverters
{
    public class PlayerMuteToVisualBrushConverter : IValueConverter
    {
        public VisualBrush MuteBrush { get; set; }
        public VisualBrush VolumeBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && (bool)value ? this.MuteBrush : this.VolumeBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
