namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class TransferDetailView : ContentPage
{
    public TransferDetailView(TransferDetailViewModel transferDetailViewModel)
    {
        InitializeComponent();
        BindingContext = transferDetailViewModel;
    }
}
