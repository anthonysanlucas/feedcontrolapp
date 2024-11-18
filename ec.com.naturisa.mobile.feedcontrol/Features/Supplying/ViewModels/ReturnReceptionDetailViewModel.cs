
namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

[QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
public partial class ReturnReceptionDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private FeedTransferModel selectedTransfer;

    [ObservableProperty]
    private FeedTransferDetailCustomResponseModel selectedTransferDetail;

    [ObservableProperty]
    private ObservableCollection<FeedTransferPoolDetailCustomResponse> feedTransferDetails;

    [ObservableProperty]
    private bool isReturnReception = false;

    private readonly IFeedTransferDetailService _feedTransferDetailService;

    public ReturnReceptionDetailViewModel(IToastService toastService) : base(toastService)
    {
    }

    #region commands
    [RelayCommand]
    async Task MarkReception()
    {

    }

    #endregion

    partial void OnSelectedTransferChanged(FeedTransferModel value)
    {
        if (value != null)
        {
            LoadFeedTransferDetails((int)value.IdFeedTransfer);
        }
        return;
    }

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

            ReturnReception();
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

    private void ReturnReception()
    {
        if (SelectedTransfer.Status == Const.Status.Transfer.AtDestination)
        {
            IsReturnReception = true;
        }
    }
}
