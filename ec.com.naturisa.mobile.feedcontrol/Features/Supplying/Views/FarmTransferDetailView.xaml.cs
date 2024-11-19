namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class FarmTransferDetailView : ContentPage
{
	public FarmTransferDetailView(FarmTransferDetailViewModel farmTransferDetailViewModel)
	{
		InitializeComponent();
        BindingContext = farmTransferDetailViewModel;
    }
}