namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class PoolTransferReceptionView : ContentPage
{
    public PoolTransferReceptionView(PoolTransferReceptionViewModel poolTransferReceptionViewModel)
    {
        InitializeComponent();
        BindingContext = poolTransferReceptionViewModel;
    }
}
