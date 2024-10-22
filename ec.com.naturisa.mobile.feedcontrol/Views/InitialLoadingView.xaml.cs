namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class InitialLoadingView : ContentPage
{
    public InitialLoadingView(InitialLoadingViewModel initialLoadingViewModel)
    {
        InitializeComponent();
        BindingContext = initialLoadingViewModel;
    }
}
