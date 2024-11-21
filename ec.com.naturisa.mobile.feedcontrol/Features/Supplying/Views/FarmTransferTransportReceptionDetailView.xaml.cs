namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class FarmTransferTransportReceptionDetailView : ContentPage
{
	public FarmTransferTransportReceptionDetailView(FarmTransferTransportReceptionDetailViewModel farmTransferTransportReceptionDetailViewModel)
	{
		InitializeComponent();
        BindingContext = farmTransferTransportReceptionDetailViewModel;
    }
}