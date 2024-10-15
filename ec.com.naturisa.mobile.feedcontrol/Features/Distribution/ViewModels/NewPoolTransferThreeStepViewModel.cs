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
        private decimal totalWeight;

        public NewPoolTransferThreeStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToPoolTransferView()
        {
            // Create a new List of FeedTransferDetailModel instances
            var feedTransferDetailModels = new List<FeedTransferDetailModel>();

            // Iterate over each PoolTransferTwoStepSelectionModel instance
            foreach (PoolTransferTwoStepSelectionModel detail in PoolTransferTwoStepSelectionModels)
            {
                var feedTransferDetailModel = new FeedTransferDetailModel
                {
                    ProductId = detail.SelectedProduct.ProductId,
                    ProductName = detail.SelectedProduct.ProductName,
                };

                feedTransferDetailModels.Add(feedTransferDetailModel);
            }

            var feedTransferModel = new FeedTransferModel
            {
                TransferCode = "T0001",
                TotalSacks = TotalQuantitySacks,
                TotalWeight = TotalWeight,
                DestinationSubsidiaryId = 2,
                DestinationSubsidiaryName = PoolTransferOneStepSelection.OriginBranch,
                OriginSubsidiaryId = 2,
                OriginSubsidiaryName = PoolTransferOneStepSelection.OriginBranch,
                AssignedDate = DateTime.Now,
                Type = "PISCINA",
                AssignedCarrierId = PoolTransferOneStepSelection.SelectedCarrier.Id,
                AssignedVehicleId = PoolTransferOneStepSelection.SelectedTransport.Id,
                AssignedVehiclePlate = PoolTransferOneStepSelection.SelectedTransport.Plate,
                AssignedCarrierName = PoolTransferOneStepSelection.SelectedCarrier.Name,
                FeedTransferDetails = feedTransferDetailModels
            };

            Console.WriteLine($"{TotalQuantitySacks} - {TotalWeight}");

            await Shell.Current.GoToAsync(nameof(PoolTransferView));
        }
    }
}
