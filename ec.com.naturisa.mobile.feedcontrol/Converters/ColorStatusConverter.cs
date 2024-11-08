﻿namespace ec.com.naturisa.mobile.feedcontrol.Converters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not null && parameter is string propertyName)
            {
                Color Amber500 = (Color)Application.Current.Resources["Amber500"];
                Color Yellow400 = (Color)Application.Current.Resources["Yellow400"];
                Color Sky600 = (Color)Application.Current.Resources["Sky600"];
                Color Indigo600 = (Color)Application.Current.Resources["Indigo600"];
                Color Green500 = (Color)Application.Current.Resources["Green500"];
                Color Neutral500 = (Color)Application.Current.Resources["Neutral500"];

                if ((string)value == Const.Status.Transfer.Assigned)
                    return Amber500;

                if ((string)value == Const.Status.Transfer.Received)
                    return Yellow400;

                if ((string)value == Const.Status.Transfer.InRoute || (string)value == Const.Status.Feed.OnCourse)
                    return Sky600;               

                if ((string)value == Const.Status.Transfer.AtDestination)
                    return Indigo600;

                if ((string)value == Const.Status.Transfer.Delivered || (string)value == Const.Status.Feed.Fed || (string)value == Const.Status.FeedRemaining.Completed)
                    return Green500;

                if ((string)value == Const.Status.Transfer.Paused)
                    return Neutral500;
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
