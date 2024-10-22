namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;

public partial class NewPoolTransferThreeStepView : ContentPage
{
    public NewPoolTransferThreeStepView(
        NewPoolTransferThreeStepViewModel newPoolTransferThreeStepViewModel
    )
    {
        InitializeComponent();
        BindingContext = newPoolTransferThreeStepViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
