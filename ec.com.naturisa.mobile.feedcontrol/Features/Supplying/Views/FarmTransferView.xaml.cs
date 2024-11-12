namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class FarmTransferView : ContentPage
{
	public FarmTransferView(FarmTransferViewModel farmTransferViewModel)
	{
		InitializeComponent();
        BindingContext = farmTransferViewModel;
    }
}