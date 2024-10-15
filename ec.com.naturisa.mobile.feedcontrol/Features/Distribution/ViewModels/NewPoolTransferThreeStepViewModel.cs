namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(PoolTransferOneStepSelection), nameof(PoolTransferOneStepSelection))]
    [QueryProperty(
        nameof(PoolTransferTwoStepSelectionModels),
        nameof(PoolTransferTwoStepSelectionModels)
    )]
    public partial class NewPoolTransferThreeStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private ObservableCollection<PoolTransferTwoStepSelectionModel> poolTransferTwoStepSelectionModels;

        public NewPoolTransferThreeStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToPoolTransferView()
        {
            await Shell.Current.GoToAsync(nameof(PoolTransferView));
        }

        //public int TotalSacks =>
        //    PoolTransferTwoStepSelectionModels.Sum(line => line.SelectedPool.QuantitySacks);

        //public double TotalWeight => TotalSacks * 25;
    }
}
