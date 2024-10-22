namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class WallInventoryView : ContentPage
{
    public WallInventoryView(WallInventoryViewModel wallInventoryViewModel)
    {
        InitializeComponent();
        BindingContext = wallInventoryViewModel;
    }
}
