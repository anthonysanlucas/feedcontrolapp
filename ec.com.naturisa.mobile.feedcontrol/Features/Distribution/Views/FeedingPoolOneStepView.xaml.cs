namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class FeedingPoolOneStepView : ContentPage
{
    public FeedingPoolOneStepView(FeedingPoolOneStepViewModel feedingPoolOneStepViewModel)
    {
        InitializeComponent();

        BindingContext = feedingPoolOneStepViewModel;
    }
}
