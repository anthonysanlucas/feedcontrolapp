namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FeedingPoolDetailView : ContentPage
{
    public FeedingPoolDetailView(FeedingPoolDetailViewModel feedingPoolDetailViewModel)
    {
        InitializeComponent();
        BindingContext = feedingPoolDetailViewModel;
    }
}
