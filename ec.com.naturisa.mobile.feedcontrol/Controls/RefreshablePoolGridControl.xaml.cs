using System.Windows.Input;

namespace ec.com.naturisa.mobile.feedcontrol.Controls;

public partial class RefreshablePoolGridControl : ContentView
{
    public static readonly BindableProperty ItemsSourceProperty =
             BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(RefreshablePoolGridControl), null);

    public static readonly BindableProperty RefreshCommandProperty =
        BindableProperty.Create(nameof(RefreshCommand), typeof(ICommand), typeof(RefreshablePoolGridControl), null);

    public static readonly BindableProperty ItemTappedCommandProperty =
        BindableProperty.Create(nameof(ItemTappedCommand), typeof(ICommand), typeof(RefreshablePoolGridControl), null);

    public static readonly BindableProperty IsRefreshingProperty =
        BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(RefreshablePoolGridControl), false);

    public RefreshablePoolGridControl()
    {
        InitializeComponent();
    }

    public IEnumerable<object> ItemsSource
    {
        get => (IEnumerable<object>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public ICommand RefreshCommand
    {
        get => (ICommand)GetValue(RefreshCommandProperty);
        set => SetValue(RefreshCommandProperty, value);
    }

    public ICommand ItemTappedCommand
    {
        get => (ICommand)GetValue(ItemTappedCommandProperty);
        set => SetValue(ItemTappedCommandProperty, value);
    }

    public bool IsRefreshing
    {
        get => (bool)GetValue(IsRefreshingProperty);
        set => SetValue(IsRefreshingProperty, value);
    }
}