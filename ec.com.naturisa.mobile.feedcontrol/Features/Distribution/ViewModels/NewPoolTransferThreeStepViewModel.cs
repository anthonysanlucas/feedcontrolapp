namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(PoolTransferOneStepSelection), nameof(PoolTransferOneStepSelection))]
    [QueryProperty(
        nameof(PoolTransferTwoStepSelectionModel),
        nameof(PoolTransferTwoStepSelectionModel)
    )]
    public partial class NewPoolTransferThreeStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private PoolTransferTwoStepSelectionModel poolTransferOneStepSelectionModel;

        public NewPoolTransferThreeStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToPoolTransferView()
        {
            await Shell.Current.GoToAsync(nameof(PoolTransferView));
        }
    }
}
