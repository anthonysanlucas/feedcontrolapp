namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class FeedingPoolTwoStepView : ContentPage
{
    public FeedingPoolTwoStepView(FeedingPoolTwoStepViewModel feedingPoolTwoStepViewModel)
    {
        InitializeComponent();
        BindingContext = feedingPoolTwoStepViewModel;
    }
}
