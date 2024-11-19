namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class ReturnReceptionDetailView : ContentPage
{
	public ReturnReceptionDetailView(ReturnReceptionDetailViewModel returnReceptionDetailViewModel)
	{
		InitializeComponent();
		BindingContext = returnReceptionDetailViewModel;
	}
}