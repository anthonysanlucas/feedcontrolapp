namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(PoolTransferOneStepSelection), nameof(PoolTransferOneStepSelection))]
    [QueryProperty(
        nameof(PoolTransferTwoStepSelectionModels),
        nameof(PoolTransferTwoStepSelectionModels)
    )]
    [QueryProperty(nameof(TotalQuantitySacks), nameof(TotalQuantitySacks))]
    [QueryProperty(nameof(TotalWeight), nameof(TotalWeight))]
    public partial class NewPoolTransferThreeStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private ObservableCollection<PoolTransferTwoStepSelectionModel> poolTransferTwoStepSelectionModels;

        [ObservableProperty]
        private int totalQuantitySacks;

        [ObservableProperty]
        private double totalWeight;

        public NewPoolTransferThreeStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToPoolTransferView()
        {
            Console.WriteLine($"{TotalQuantitySacks} - {TotalWeight}");

            await Shell.Current.GoToAsync(nameof(PoolTransferView));
        }
    }
}
