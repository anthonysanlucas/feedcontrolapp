namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
    public partial class PoolTransferReceptionViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferModel selectedTransfer;

        [ObservableProperty]
        private FeedTransferDetailCustomResponseModel selectedTransferDetail;

        [ObservableProperty]
        private ObservableCollection<FeedTransferPoolDetailCustomResponse> feedTransferDetails;

        private readonly IFeedTransferService _feedTransferService;

        private readonly IFeedTransferDetailService _feedTransferDetailService;

        public PoolTransferReceptionViewModel(
            IToastService toastService,
            IFeedTransferService feedTransferService,
            IFeedTransferDetailService feedTransferDetailService
        )
            : base(toastService)
        {
            _feedTransferService = feedTransferService;
            _feedTransferDetailService = feedTransferDetailService;
        }

        partial void OnSelectedTransferChanged(FeedTransferModel value)
        {
            if (value != null)
            {
                LoadFeedTransferDetails((int)value.IdFeedTransfer);
            }
            return;
        }

        [RelayCommand]
        async Task UpdateToReceivedFeedTransferStatus(int id)
        {
            if (!AllDetailsChecked())
            {
                await ToastService.ShowToastAsync(
                    "Debe marcar todos los detalles antes de continuar."
                );
                return;
            }

            try
            {
                IsBusy = true;

                var response = await _feedTransferService.PatchFeedTransferStatus(id, "RECIBIDO");

                if (response != null && response.Code == 200)
                {
                    await ToastService.ShowToastAsync("Estado actualizado exitosamente.");

                    await Shell.Current.GoToAsync("..");
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

        private bool AllDetailsChecked()
        {
            return FeedTransferDetails != null
                && FeedTransferDetails.All(detail => detail.IsChecked);
        }
    }
}
