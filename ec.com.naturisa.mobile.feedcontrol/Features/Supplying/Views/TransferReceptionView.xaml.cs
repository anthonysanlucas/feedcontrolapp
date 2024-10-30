namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class TransferReceptionView : ContentPage
{
	public TransferReceptionView(TransferReceptionViewModel transferReceptionViewModel)
	{
		InitializeComponent();
		BindingContext = transferReceptionViewModel;
	}
}