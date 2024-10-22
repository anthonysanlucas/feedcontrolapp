namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class NewTransferTwoStepView : ContentPage
{
    public NewTransferTwoStepView(NewTransferTwoStepViewModel newTransferTwoStepViewModel)
    {
        InitializeComponent();
        BindingContext = newTransferTwoStepViewModel;
    }
}
