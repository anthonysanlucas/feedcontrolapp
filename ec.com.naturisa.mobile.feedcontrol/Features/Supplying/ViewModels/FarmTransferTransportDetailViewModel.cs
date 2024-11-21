namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

[QueryProperty(nameof(WarehouseTransfer), nameof(WarehouseTransfer))]
public partial class FarmTransferTransportDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarehouseTransferResponse warehouseTransfer;

    [ObservableProperty]
    private ObservableCollection<WarehouseTransferDetailResponse> warehouseDetails;

    [ObservableProperty]
    private WarehouseTransferDetailQuery transferDetailQuery;

    [ObservableProperty]
    private bool isCheckVisible = false;

    private IWarehouseTransferDetailService _warehouseTransferDetailService;

    public FarmTransferTransportDetailViewModel(IWarehouseTransferDetailService warehouseTransferDetailService, IToastService toastService) : base(toastService)
    {
        _warehouseTransferDetailService = warehouseTransferDetailService;
    }

    partial void OnWarehouseTransferChanged(WarehouseTransferResponse value)
    {
        if (value != null)
        {
            LoadFeedTransferDetails((int)value.IdWarehouseTransfer);

            if (value.LastStatusCatalogueName === Const.Status.Transfer.Assigned)
            {
                IsCheckVisible = true;
            }
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

    #region commands
    [RelayCommand]
    async Task MarkReception()
    {

    }

    async Task StartRoute()
    {

    }
    #endregion
}
