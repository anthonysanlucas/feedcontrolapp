namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FeedingRemainingView : ContentPage
{
    public FeedingRemainingView(FeedingRemainingViewModel feedingRemainingViewModel)
    {
        InitializeComponent();
        BindingContext = feedingRemainingViewModel;
    }
}
