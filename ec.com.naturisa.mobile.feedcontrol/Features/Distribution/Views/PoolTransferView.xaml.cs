namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class PoolTransferView : ContentPage
{
    public PoolTransferView(PoolTransferViewModel poolTransferViewModel)
    {
        InitializeComponent();
        BindingContext = poolTransferViewModel;
    }
}
