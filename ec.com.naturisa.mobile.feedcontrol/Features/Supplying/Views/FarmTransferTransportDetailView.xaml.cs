namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class FarmTransferTransportDetailView : ContentPage
{
	public FarmTransferTransportDetailView(FarmTransferTransportDetailViewModel farmTransferTransportDetailViewModel)
	{
		InitializeComponent();
		BindingContext = farmTransferTransportDetailViewModel;
    }
}