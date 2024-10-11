namespace ec.com.naturisa.mobile.feedcontrol.Views.Components;

public partial class StatusIndicator : ContentView
{
    // Definición de la propiedad BindableProperty
    public static readonly BindableProperty StatusProperty = BindableProperty.Create(
        propertyName: nameof(Status),
        returnType: typeof(string),
        declaringType: typeof(StatusIndicator),
        defaultValue: string.Empty,
        propertyChanged: OnStatusChanged
    );

    // Propiedad vinculable Status
    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    // Propiedades dependientes de Status
    public Color StatusColor => GetStatusColor(Status);
    public Color StatusTextColor => GetTextColor(Status);
    public string StatusText => Status;

    public StatusIndicator()
    {
        InitializeComponent();
    }

    private static void OnStatusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (StatusIndicator)bindable;
        control.UpdateStatus();
    }

    // Actualiza las propiedades del componente basadas en el nuevo estado
    private void UpdateStatus()
    {
        OnPropertyChanged(nameof(StatusColor));
        OnPropertyChanged(nameof(StatusText));
        OnPropertyChanged(nameof(StatusTextColor));
    }

    // Devuelve el color basado en el valor del estado
    private static Color GetTextColor(string status)
    {
        // Método auxiliar para obtener el color de los recursos.
        Color GetResourceColor(string resourceKey)
        {
            if (Application.Current.Resources.TryGetValue(resourceKey, out var color))
            {
                return (Color)color;
            }
            return Colors.DarkGray;
        }

        return status switch
        {
            "ASIGNADO" => GetResourceColor("Amber500"),
            "RECIBIDO" => GetResourceColor("Primary700"),
            "TRANSITO" => GetResourceColor("Primary"),
            "PAUSADO" => GetResourceColor("Primary"),
            "FINALIZADO" => GetResourceColor("Primary700"),
            "ENTREGADO" => GetResourceColor("Green500"),
            _ => Colors.DarkGray
        };
    }

    private static Color GetStatusColor(string status)
    {
        // Método auxiliar para obtener el color de los recursos.
        Color GetResourceColor(string resourceKey)
        {
            if (Application.Current.Resources.TryGetValue(resourceKey, out var color))
            {
                return (Color)color;
            }
            return Colors.DarkGray;
        }

        return status switch
        {
            "ASIGNADO" => GetResourceColor("Primary100"),
            "RECIBIDO" => GetResourceColor("Primary100"),
            "TRANSITO" => GetResourceColor("Primary100"),
            "FINALIZADO" => GetResourceColor("Primary100"),
            "ENTREGADO" => GetResourceColor("Primary100"),
            _ => Colors.DarkGray
        };
    }
}
