namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class FarmTransferTransportView : ContentPage
{
	public FarmTransferTransportView(FarmTransferTransportViewModel farmTransferTransportViewModel)
	{
		InitializeComponent();
        BindingContext = farmTransferTransportViewModel;
    }
}