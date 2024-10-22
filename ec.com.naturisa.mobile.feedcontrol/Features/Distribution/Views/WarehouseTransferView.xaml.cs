namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class WarehouseTransferView : ContentPage
{
    public WarehouseTransferView(WarehouseTransferViewModel warehouseTransferViewModel)
    {
        InitializeComponent();
        BindingContext = warehouseTransferViewModel;
    }
}
