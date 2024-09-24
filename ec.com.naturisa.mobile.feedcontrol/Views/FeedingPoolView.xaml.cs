namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FeedingPoolView : ContentPage
{
    public FeedingPoolView(FeedingPoolViewModel feedingPoolViewModel)
    {
        InitializeComponent();
        BindingContext = feedingPoolViewModel;

        SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        if (BindingContext is FeedingPoolViewModel viewModel)
        {
            viewModel.CollectionViewWidth = poolListCollectionView.Width;
        }
    }
}
