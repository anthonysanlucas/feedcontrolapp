namespace ec.com.naturisa.mobile.feedcontrol.Converters
{
    public class PoolColorStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue && parameter is string propertyName)
            {
                var Green500 = (Color)Application.Current.Resources["Green500"];
                var Amber500 = (Color)Application.Current.Resources["Amber500"];

                if (propertyName == "IsFeeding")
                {
                    return booleanValue ? Green500 : Amber500;
                }

                if (propertyName == "IsRemaining")
                {
                    return booleanValue ? Green500 : Amber500;
                }
            }

            return Colors.Transparent;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            throw new NotImplementedException();
        }
    }
}
