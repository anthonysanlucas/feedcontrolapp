namespace ec.com.naturisa.mobile.feedcontrol.Features.Transport.Views;

public partial class TripsView : ContentPage
{
	public TripsView(TripsViewModel tripsViewModel)
	{
		InitializeComponent();
        BindingContext = tripsViewModel;
    }
}