namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class NewPoolTransferOneStepView : ContentPage
{
    public NewPoolTransferOneStepView(
        NewPoolTransferOneStepViewModel newPoolTransferOneStepViewModel
    )
    {
        InitializeComponent();
        BindingContext = newPoolTransferOneStepViewModel;
    }
}
