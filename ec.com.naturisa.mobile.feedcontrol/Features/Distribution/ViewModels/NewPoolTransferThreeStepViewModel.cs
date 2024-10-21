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

        public NewPoolTransferThreeStepViewModel(IToastService toastService)
            : base(toastService)
        {
            _feedTransferService = new FeedTransferService();
        }

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
                    Weight = group.Sum(item => item.QuantitySacks ?? 0) * 25,
                    FeedTransferDetailPools = group
                        .Select(detail => new FeedTransferDetailPoolModel
                        {
                            PoolId = detail.SelectedPool.PoolId,
                            PoolCode = detail.SelectedPool.PoolCode,
                            QuantitySacks = detail.QuantitySacks ?? 0,
                            Weight = (double)(detail.QuantitySacks * 25),
                            Status = detail.SelectedPool.Status
                        })
                        .ToList()
                })
                .ToList();

            DestinationPools = string.Join(
                " ",
                PoolTransferTwoStepSelectionModels.Select(detail => detail.SelectedPool.PoolCode)
            );

            // PLACA-AÑOMESDIA-1
            var feedTransferModel = new FeedTransferModel
            {
                TransferCode = $"{PoolTransferOneStepSelection.SelectedTransport.Plate}-20241021-1",
                TotalSacks = TotalQuantitySacks,
                TotalWeight = TotalWeight,
                DestinationSubsidiaryId = 2,
                DestinationSubsidiaryName = DestinationPools,
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

            try
            {
                var response = await _feedTransferService.PostFeedTransfer(feedTransferModel);

                if (response.Code == 201) { }
                else
                {
                    await ToastService.ShowToastAsync($"Error: {response.Message}");
                    return;
                }
            }
            catch (HttpRequestException httpEx)
            {
                //await ToastService.ShowToastAsync($"Error de red: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                //await ToastService.ShowToastAsync($"Error inesperado: {ex.Message}");
            }

            await ToastService.ShowToastAsync("Viaje asignado correctamente.");
            await Shell.Current.GoToAsync($"//{nameof(PoolTransferView)}");
        }
    }
}
