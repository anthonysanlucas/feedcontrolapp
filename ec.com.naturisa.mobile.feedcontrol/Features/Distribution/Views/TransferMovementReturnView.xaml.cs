namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class TransferMovementReturnView : ContentPage
{
	public TransferMovementReturnView(TransferMovementReturnViewModel transferMovementReturnViewModel)
	{
		InitializeComponent();
		BindingContext = transferMovementReturnViewModel;
	}
}