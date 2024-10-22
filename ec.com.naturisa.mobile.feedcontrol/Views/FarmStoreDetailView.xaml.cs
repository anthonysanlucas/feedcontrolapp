namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class FarmStoreDetailView : ContentPage
{
    public FarmStoreDetailView(FarmStoreDetailViewModel farmStoreDetailViewModel)
    {
        InitializeComponent();
        BindingContext = farmStoreDetailViewModel;
    }
}
