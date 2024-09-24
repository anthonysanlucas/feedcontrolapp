namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FeedingMovementsView : ContentPage
{
    public FeedingMovementsView(FeedingMovementsViewModel feedingMovementsViewModel)
    {
        InitializeComponent();
        BindingContext = feedingMovementsViewModel;
    }
}
