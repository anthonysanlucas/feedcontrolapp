namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class NewPoolTransferTwoStepView : ContentPage
{
    public NewPoolTransferTwoStepView(
        NewPoolTransferTwoStepViewModel newPoolTransferTwoStepViewModel
    )
    {
        InitializeComponent();
        BindingContext = newPoolTransferTwoStepViewModel;
    }
}
