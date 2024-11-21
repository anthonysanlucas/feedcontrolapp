namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

[QueryProperty(nameof(WarehouseTransfer), nameof(WarehouseTransfer))]
public partial class FarmTransferTransportReceptionDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarehouseTransferResponse warehouseTransfer;

    [ObservableProperty]
    private ObservableCollection<WarehouseTransferDetailResponse> warehouseDetails;

    [ObservableProperty]
    private WarehouseTransferDetailQuery transferDetailQuery;

    [ObservableProperty]
    private bool isCheckVisible = false;

    [ObservableProperty]
    private bool isMainBtnVisible = false;

    [ObservableProperty]
    private string mainBtnText = string.Empty;

    private IWarehouseTransferDetailService _warehouseTransferDetailService;

    private IWarehouseTransferService _warehouseTransferService;

    public FarmTransferTransportReceptionDetailViewModel(IWarehouseTransferService warehouseTransferService, IWarehouseTransferDetailService warehouseTransferDetailService, IToastService toastService) : base(toastService)
    {
        _warehouseTransferService = warehouseTransferService;
        _warehouseTransferDetailService = warehouseTransferDetailService;
    }

    partial void OnWarehouseTransferChanged(WarehouseTransferResponse value)
    {
        if (value != null)
        {
            LoadFeedTransferDetails((int)value.IdWarehouseTransfer);

            if (value.LastStatusCatalogueName == Const.Status.Transfer.AtDestination)
            {
                IsCheckVisible = true;
                IsMainBtnVisible = true;
                MainBtnText = "Registrar llegada a destino";
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
    async Task ChangeStatus()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            string nextStatus = Const.Status.Transfer.Delivered;

            var response = await _warehouseTransferService.ChangeStatus(WarehouseTransfer.IdWarehouseTransfer, nextStatus);

            if (response == null || response.Code != 200)
            {
                await ShowToastAsync(response?.Message ?? "Ha ocurrido un error, intente nuevamente");
                return;
            }

            await Shell.Current.Navigation.PopAsync();
            await ShowToastAsync("Estado cambiado correctamente.");
        }
        catch
        {
            await ShowToastAsync("Ha ocurrido un error, intente nuevamente.");
        }
        finally
        {
            IsBusy = false;
        }

    }
    #endregion
}
