namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.Views;

public partial class ReturnReceptionView : ContentPage
{
    public ReturnReceptionView(ReturnReceptionViewModel returnReceptionViewModel)
    {
        InitializeComponent();
        BindingContext = returnReceptionViewModel;
    }
}