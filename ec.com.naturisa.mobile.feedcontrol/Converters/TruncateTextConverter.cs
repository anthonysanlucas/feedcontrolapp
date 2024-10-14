namespace ec.com.naturisa.mobile.feedcontrol.Converters
{
    public class TruncateTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                var words = text.Split(' ');
                int maxWords = parameter != null ? int.Parse(parameter.ToString()) : 3;

                if (words.Length > maxWords)
                {
                    return string.Join(" ", words.Take(maxWords)) + "...";
                }

                return text;
            }

            return value;
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
