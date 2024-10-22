namespace ec.com.naturisa.mobile.feedcontrol.Converters
{
    public class PoolListSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width)
            {
                // Tamaño del cuadro + márgenes
                double itemSize = 90;
                double spacing = 6; // Ajusta este valor si tienes márgenes u otros espacios

                // Calcula el ancho máximo disponible para items
                double availableWidth = width - (spacing * 2); // Ajusta según los márgenes

                // Calcula el número de items que caben en el ancho disponible
                int span = (int)(availableWidth / (itemSize + spacing));

                // Devuelve un mínimo de 2 para evitar que el número de columnas sea demasiado bajo
                return Math.Max(span, 2);
            }
            return 4; // Valor predeterminado si no se puede obtener el ancho
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
