using ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransferDetail;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

[QueryProperty(nameof(WarehouseTransfer), nameof(WarehouseTransfer))]
public partial class FarmTransferDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarehouseTransferResponse warehouseTransfer;

    [ObservableProperty]
    private ObservableCollection<WarehouseTransferDetailResponse> warehouseDetails;

    [ObservableProperty]
    private WarehouseTransferDetailQuery transferDetailQuery;

    private IWarehouseTransferDetailService _warehouseTransferDetailService;

    public FarmTransferDetailViewModel(IWarehouseTransferDetailService warehouseTransferDetailService, IToastService toastService) : base(toastService)
    {
        _warehouseTransferDetailService = warehouseTransferDetailService;
    }

    partial void OnWarehouseTransferChanged(WarehouseTransferResponse value)
    {
        if (value != null)
        {
            LoadFeedTransferDetails((int)value.IdWarehouseTransfer);
        }

        return;
    }

    private async void LoadFeedTransferDetails(int id)
    {
        try
        {
            IsBusy = true;

            TransferDetailQuery = new WarehouseTransferDetailQuery
            {
                IncludeProduct = true,
                WarehouseTransferId = id
            };

            var transferDetailsResponse =
                await _warehouseTransferDetailService.GetWarehouseTransfers(
                    TransferDetailQuery
                );

            if (transferDetailsResponse == null || transferDetailsResponse.Code != 200)
            {
                await ToastService.ShowToastAsync("Error al cargar los detalles del viaje.");
                return;
            }

            WarehouseDetails = new ObservableCollection<WarehouseTransferDetailResponse>(
                (IEnumerable<WarehouseTransferDetailResponse>)(transferDetailsResponse.Data.Data));
        }
        catch (Exception ex)
        {
            await ToastService.ShowToastAsync($"Ocurrió un error, intente nuevamente.");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
