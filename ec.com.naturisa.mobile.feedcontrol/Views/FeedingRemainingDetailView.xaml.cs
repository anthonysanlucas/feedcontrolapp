namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FeedingRemainingDetailView : ContentPage
{
    public FeedingRemainingDetailView(
        FeedingRemainingDetailViewModel feedingRemainingDetailViewModel
    )
    {
        InitializeComponent();

        BindingContext = feedingRemainingDetailViewModel;
    }
}
