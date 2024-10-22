namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class InventoryIncomeDetailView : ContentPage
{
    public InventoryIncomeDetailView(InventoryIncomeDetailViewModel inventoryIncomeDetailViewModel)
    {
        InitializeComponent();
        BindingContext = inventoryIncomeDetailViewModel;
    }
}
