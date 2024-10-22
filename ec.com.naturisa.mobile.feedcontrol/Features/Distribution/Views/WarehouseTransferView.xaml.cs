using CommunityToolkit.Mvvm.Messaging;
using ec.com.naturisa.mobile.feedcontrol.Helpers;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class WarehouseTransferView : ContentPage
{
    public WarehouseTransferView(WarehouseTransferViewModel warehouseTransferViewModel)
    {
        InitializeComponent();
        BindingContext = warehouseTransferViewModel;

        //WeakReferenceMessenger.Default.Register<RefreshDataMessenger>(this, (r, message) =>
        //{
        //    if (message.Value)
        //    {
        //        //warehouseTransferViewModel.;
        //    }
        //});
    }
}
