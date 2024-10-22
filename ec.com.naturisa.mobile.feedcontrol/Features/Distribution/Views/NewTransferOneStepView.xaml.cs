namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class NewTransferOneStepView : ContentPage
{
    public NewTransferOneStepView(NewTransferOneStepViewModel newTransferOneStepViewModel)
    {
        InitializeComponent();
        BindingContext = newTransferOneStepViewModel;
    }
}
