namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class PoolTransferDetailView : ContentPage
{
    public PoolTransferDetailView(PoolTransferDetailViewModel poolTransferDetailViewModel)
    {
        InitializeComponent();
        BindingContext = poolTransferDetailViewModel;
    }
}
