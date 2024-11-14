namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(PoolTransferOneStepSelection), nameof(PoolTransferOneStepSelection))]
    [QueryProperty(nameof(PoolTransferTwoStepSelectionModels), nameof(PoolTransferTwoStepSelectionModels))]
    [QueryProperty(nameof(TotalQuantitySacks), nameof(TotalQuantitySacks))]
    [QueryProperty(nameof(TotalWeight), nameof(TotalWeight))]
    public partial class NewTransferThreeStepViewModel : BaseViewModel
    {
        private readonly FeedTransferService _feedTransferService;

        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private ObservableCollection<PoolTransferTwoStepSelectionModel> poolTransferTwoStepSelectionModels;

        [ObservableProperty]
        private int totalQuantitySacks;

        [ObservableProperty]
        private decimal totalWeight;

        [ObservableProperty]
        private string destinationPools;

        public NewTransferThreeStepViewModel(IToastService toastService)
            : base(toastService) { }

        partial void OnPoolTransferTwoStepSelectionModelsChanged(ObservableCollection<PoolTransferTwoStepSelectionModel> value)
        {
            DestinationPools = string.Join(
                " ",
                value.Select(detail => detail.SelectedPool.PoolCode)
            );
        }
    }
}
