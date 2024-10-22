namespace ec.com.naturisa.mobile.feedcontrol.Views.Components;

public partial class StatusIndicator : ContentView
{
    public static readonly BindableProperty StatusProperty = BindableProperty.Create(
     propertyName: nameof(Status),
     returnType: typeof(string),
     declaringType: typeof(StatusIndicator),
     defaultValue: string.Empty,
     propertyChanged: OnStatusChanged
);
    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

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

    private void UpdateStatus()
    {
        OnPropertyChanged(nameof(StatusColor));
        OnPropertyChanged(nameof(StatusText));
        OnPropertyChanged(nameof(StatusTextColor));
    }

    private static Color GetTextColor(string status)
    {
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
            "RECIBIDO" => GetResourceColor("Yellow400"),
            "EN RUTA" => GetResourceColor("Sky600"),
            "FINALIZADO" => GetResourceColor("Indigo600"),
            "ENTREGADO" => GetResourceColor("Green600"),
            "PAUSADO" => GetResourceColor("Neutral500"),
            _ => Colors.DarkGray
        };
    }

    private static Color GetStatusColor(string status)
    {
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
            "ASIGNADO" => GetResourceColor("Amber50"),
            "RECIBIDO" => GetResourceColor("Primary100"),
            "TRANSITO" => GetResourceColor("Primary100"),
            "FINALIZADO" => GetResourceColor("Green100"),
            "ENTREGADO" => GetResourceColor("Primary100"),
            _ => Colors.DarkGray
        };
    }
}
