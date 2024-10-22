namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class PoolTransferDeliveryDetailView : ContentPage
{
    public PoolTransferDeliveryDetailView(
        PoolTransferDeliveryDetailViewModel poolTransferDeliveryDetailViewModel
    )
    {
        InitializeComponent();
        BindingContext = poolTransferDeliveryDetailViewModel;
    }
}
