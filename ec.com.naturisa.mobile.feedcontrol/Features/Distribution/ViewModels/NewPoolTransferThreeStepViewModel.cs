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
            var groupedByProduct = PoolTransferTwoStepSelectionModels
                .GroupBy(detail => detail.SelectedProduct.ProductName)
                .Select(group => new FeedTransferDetailModel
                {
                    ProductId = group.First().SelectedProduct.ProductId,
                    ProductName = group.Key,
                    QuantitySacks = group.Sum(item => item.QuantitySacks ?? 0),
                    FeedTransferDetailPools = group
                        .Select(detail => new FeedTransferDetailPoolModel
                        {
                            PoolId = detail.SelectedPool.PoolId,
                            PoolCode = detail.SelectedPool.PoolCode,
                            QuantitySacks = detail.QuantitySacks ?? 0,
                            Weight = detail.SelectedPool.Weight,
                            Status = detail.SelectedPool.Status
                        })
                        .ToList()
                })
                .ToList();

            foreach (var product in groupedByProduct)
            {
                Console.WriteLine($"{product.ProductName} {product.QuantitySacks}");

                foreach (var pool in product.FeedTransferDetailPools)
                {
                    Console.WriteLine($"- {pool.PoolCode} {pool.QuantitySacks}");
                }
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
                FeedTransferDetails = groupedByProduct
            };

            await Shell.Current.GoToAsync(nameof(PoolTransferView));
        }
    }
}
