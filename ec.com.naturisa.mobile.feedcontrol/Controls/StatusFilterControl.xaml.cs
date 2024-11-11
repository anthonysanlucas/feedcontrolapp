using System.Windows.Input;

namespace ec.com.naturisa.mobile.feedcontrol.Controls;

public partial class StatusFilterControl : ContentView
{
	public StatusFilterControl()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty FiltersProperty =
          BindableProperty.Create(nameof(Filters), typeof(ObservableCollection<FilterStatus>), typeof(StatusFilterControl), null);

    public ObservableCollection<FilterStatus> Filters
    {
        get => (ObservableCollection<FilterStatus>)GetValue(FiltersProperty);
        set => SetValue(FiltersProperty, value);
    }

    // Comando que se ejecutará al seleccionar un filtro
    public static readonly BindableProperty FilterSelectedCommandProperty =
        BindableProperty.Create(nameof(FilterSelectedCommand), typeof(ICommand), typeof(StatusFilterControl), null);

    public ICommand FilterSelectedCommand
    {
        get => (ICommand)GetValue(FilterSelectedCommandProperty);
        set => SetValue(FilterSelectedCommandProperty, value);
    }
}