namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class StartOfRouteView : ContentPage
{
    public StartOfRouteView(StartOfRouteViewModel startOfRouteViewModel)
    {
        InitializeComponent();
        BindingContext = startOfRouteViewModel;
    }
}
