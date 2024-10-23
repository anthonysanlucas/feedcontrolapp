namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class InventoryReceptionView : ContentPage
{
    public InventoryReceptionView(InventoryReceptionViewModel inventoryReceptionViewModel)
    {
        InitializeComponent();
        BindingContext = inventoryReceptionViewModel;
    }
}
