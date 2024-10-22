namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FarmInventoryView : ContentPage
{
    public FarmInventoryView(FarmInventoryViewModel farmInventoryViewModel)
    {
        InitializeComponent();
        BindingContext = farmInventoryViewModel;
    }
}
