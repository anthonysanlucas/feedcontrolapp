namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class TransferMovementView : ContentPage
{
	public TransferMovementView(TransferMovementViewModel transferMovementViewModel)
	{
		InitializeComponent();
        BindingContext = transferMovementViewModel;
    }
}