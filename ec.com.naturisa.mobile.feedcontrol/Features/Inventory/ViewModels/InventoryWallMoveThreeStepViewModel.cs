namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

[QueryProperty(nameof(SelectedTransport), nameof(SelectedTransport))]
[QueryProperty(nameof(SelectedFreightTransporter), nameof(SelectedFreightTransporter))]
[QueryProperty(nameof(SelectedPool), nameof(SelectedPool))]
[QueryProperty(nameof(SelectedOtherPool), nameof(SelectedOtherPool))]
[QueryProperty(nameof(ProductRows), nameof(ProductRows))]
public partial class InventoryWallMoveThreeStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private TransportResponse selectedTransport;

    [ObservableProperty]
    private FreightTransporterResponse selectedFreightTransporter;

    [ObservableProperty]
    private PoolsResponse selectedPool;

    [ObservableProperty]
    private PoolsResponse selectedOtherPool;

    [ObservableProperty]
    private ObservableCollection<ProductWallRow> productRows;

    private readonly IPoolTransferService _poolTransferService;

    public InventoryWallMoveThreeStepViewModel(IToastService toastService, IPoolTransferService poolTransferService) : base(toastService)
    {
        _poolTransferService = poolTransferService;
    }

    [RelayCommand]
    async Task CreateWallReasignation()
    {
        IsBusy = true;

        try
        {
            List<PoolTransferDetailRequest> poolTransferDetailRequests = new List<PoolTransferDetailRequest>();

            foreach (var row in ProductRows)
            {
                PoolTransferDetailRequest poolTransferDetailRequest = new PoolTransferDetailRequest()
                {        
                    DestinationPoolCode = SelectedOtherPool.Name,
                    ProductId = row.SelectedProduct.IdProduct,
                    Quantity = (int)row.QuantitySacks,
                };

                poolTransferDetailRequests.Add(poolTransferDetailRequest);
            }

            PoolTransferRequest poolTransferRequest = new PoolTransferRequest()
            {
                WarehouseId = 49,
                OriginPoolCode = SelectedPool.Name,
                FreightTransporterId = SelectedFreightTransporter.IdFreightTransporter,
                TransportId = SelectedTransport.IdTransport,
                PoolTransferDetails = poolTransferDetailRequests
            };

            var response = await _poolTransferService.PostPoolTransfer(poolTransferRequest);

            if (response != null)
            {
                await ShowToastAsync("Transferencia de piscina creada correctamente");

                await Shell.Current.GoToAsync($"//{nameof(InventoryWallView)}");
            }
        }
        catch (Exception ex)
        {
            await ShowToastAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
