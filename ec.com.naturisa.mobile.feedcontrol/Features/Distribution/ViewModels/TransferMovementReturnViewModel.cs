
namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels;

[QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
public partial class TransferMovementReturnViewModel : BaseViewModel
{

    [ObservableProperty]
    private FeedTransferModel selectedTransfer;

    [ObservableProperty]
    private FeedTransferDetailCustomResponseModel selectedTransferDetail;

    [ObservableProperty]
    private ObservableCollection<FeedTransferPoolDetailCustomResponse> feedTransferDetails;

    [ObservableProperty]
    private bool isDestinationDelivery = false;

    private readonly IFeedTransferDetailService _feedTransferDetailService;

    private readonly IFeedTransferService _feedTransferService;

    public TransferMovementReturnViewModel(IFeedTransferService feedTransferService, IFeedTransferDetailService feedTransferDetailService, IToastService toastService)
        : base(toastService)
    {
        _feedTransferService = feedTransferService;
        _feedTransferDetailService = feedTransferDetailService;
    }

    #region commands
    [RelayCommand]
    async Task MarkDestination()
    {
        try
        {
            IsBusy = true;

            int id = (int)SelectedTransfer.IdFeedTransfer;

            var response = await _feedTransferService.PatchReturnStatus(
                id,
                Const.Status.Transfer.InRoute
            );

            if (response != null && response.Code == 200)
            {
                await ToastService.ShowToastAsync("Estado actualizado exitosamente.");

                LoadFeedTransferDetails(id);
            }
            else
            {
                await ToastService.ShowToastAsync(
                    "Error al actualizar el estado, intente nuevamente."
                );
            }
        }
        catch (Exception ex)
        {
            await ToastService.ShowToastAsync("Ocurrió un error, intente nuevamente.");
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    private async void LoadFeedTransferDetails(int feedTransferId)
    {
        try
        {
            IsBusy = true;
            var transferDetailsResponse =
                await _feedTransferDetailService.GetFeedTransferDetailsConsolidated(
                    feedTransferId
                );

            if (transferDetailsResponse == null || transferDetailsResponse.Code != 200)
            {
                await ToastService.ShowToastAsync("Error al cargar los detalles del viaje.");
                return;
            }

            SelectedTransferDetail = transferDetailsResponse.Data;

            FeedTransferDetails =
                new ObservableCollection<FeedTransferPoolDetailCustomResponse>(
                    (IEnumerable<FeedTransferPoolDetailCustomResponse>)(
                        transferDetailsResponse.Data.FeedTransferPoolsDetail
                    )
                );

            DestinationDelivery();
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

    partial void OnSelectedTransferChanged(FeedTransferModel value)
    {
        if (value != null)
        {
            LoadFeedTransferDetails((int)value.IdFeedTransfer);
        }
        return;
    }

    private void DestinationDelivery()
    {
        if (SelectedTransfer.Status == Const.Status.Transfer.InRoute)
        {
            IsDestinationDelivery = true;
        }
    }
}
