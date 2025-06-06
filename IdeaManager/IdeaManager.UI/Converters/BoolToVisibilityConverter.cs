﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace IdeaManager.UI.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
     
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                => string.IsNullOrWhiteSpace(value as string) ? Visibility.Collapsed : Visibility.Visible;

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                => throw new NotSupportedException();
        
    }
}
