namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class FarmTransferTransportReceptionView : ContentPage
{
	public FarmTransferTransportReceptionView(FarmTransferTransportReceptionViewModel farmTransferTransportReceptionViewModel)
	{
		InitializeComponent();
        BindingContext = farmTransferTransportReceptionViewModel;
    }
}