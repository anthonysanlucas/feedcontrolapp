using ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels;

[QueryProperty(nameof(WarehouseTransfer), nameof(WarehouseTransfer))]
[QueryProperty(nameof(OriginWarehouse), nameof(OriginWarehouse))]
[QueryProperty(nameof(DestinationWarehouse), nameof(DestinationWarehouse))]
[QueryProperty(nameof(ProductRows), nameof(ProductRows))]
[QueryProperty(nameof(TotalQuantitySacks), nameof(TotalQuantitySacks))]
[QueryProperty(nameof(TotalWeight), nameof(TotalWeight))]
public partial class NewTransferThreeStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarehouseTransferRequest warehouseTransfer;

    [ObservableProperty]
    private WarehouseResponse originWarehouse;

    [ObservableProperty]
    private WarehouseResponse destinationWarehouse;

    [ObservableProperty]
    private ObservableCollection<ProductRow> productRows;

    [ObservableProperty]
    private int totalQuantitySacks;

    [ObservableProperty]
    private decimal totalWeight;

    [ObservableProperty]
    private string destinationPools;

    private readonly IWarehouseTransferService _warehouseTransferService;

    public NewTransferThreeStepViewModel(IWarehouseTransferService warehouseTransferService, IToastService toastService)
        : base(toastService)
    {

        _warehouseTransferService = warehouseTransferService;
    }

    #region commands
    [RelayCommand]
    async Task CreateFarmTransfer()
    {
        IsBusy = true;

        try
        {
            List<WarehouseTransferDetailRequest> warehouseTransferDetailRequests = new List<WarehouseTransferDetailRequest>();

            foreach (var item in ProductRows)
            {
                if (item.SelectedProduct == null)
                {
                    await ToastService.ShowToastAsync("Por favor selecciona un producto para todas las filas.");
                    return;
                }

                if (!item.QuantitySacks.HasValue || item.QuantitySacks <= 0)
                {
                    await ToastService.ShowToastAsync("Por favor ingresa una cantidad válida de sacos.");
                    return;
                }

                WarehouseTransferDetailRequest WarehouseTransferDetailRequest = new()
                {
                    WarehouseTransferId = DestinationWarehouse.IdWarehouse,
                    ProductId = item.SelectedProduct.ProductId,
                    Quantity = (int)item.QuantitySacks,
                };

                warehouseTransferDetailRequests.Add(WarehouseTransferDetailRequest);
            }

            WarehouseTransfer = new WarehouseTransferRequest
            {
                OriginWarehouseId = OriginWarehouse.IdWarehouse,
                DestinationWarehouseId = DestinationWarehouse.IdWarehouse,
                FreightTransporterId = 16,
                TransportId = 24,
                WarehouseTransferDetails = warehouseTransferDetailRequests
            };

            var response = await _warehouseTransferService.PostWarehouseTransfer(WarehouseTransfer);
                        
            if (response.Data != null & response.Code == 200)
            {
                await ToastService.ShowToastAsync("Transferencia de bodega creada exitosamente.");

                WeakReferenceMessenger.Default.Send(new RefreshDataMessage("REFRESH"));
                await Shell.Current.Navigation.PopToRootAsync();
            }
            else
            {
                await ToastService.ShowToastAsync($"Error al crear la transferencia {response.Message}.");
            }
        }
        catch (Exception ex)
        {
            await ToastService.ShowToastAsync($"Error al crear la transferencia {ex.Message}.");
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion
}
