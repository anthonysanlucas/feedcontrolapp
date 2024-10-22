namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
    public partial class StartOfRouteViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferModel selectedTransfer;

        [ObservableProperty]
        private FeedTransferDetailCustomResponseModel selectedTransferDetail;

        [ObservableProperty]
        private FeedTransferPoolDetailCustomResponse selectedTransferPoolDetail;

        [ObservableProperty]
        private ObservableCollection<FeedTransferPoolDetailCustomResponse> feedTransferDetails;

        [ObservableProperty]
        private bool isRecieved = false;

        [ObservableProperty]
        private bool isOnRoute = false;

        private readonly IFeedTransferService _feedTransferService;

        private readonly IFeedTransferDetailService _feedTransferDetailService;

        public StartOfRouteViewModel(
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

                if (value.Status == Const.Status.Transfer.Received)
                {
                    IsRecieved = true;
                    IsOnRoute = false;
                }

                if (value.Status == Const.Status.Transfer.InRoute)
                {
                    IsRecieved = false;
                    IsOnRoute = true;
                }
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

        [RelayCommand]
        async Task LoadTwoFeedTransferDetails()
        {
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                var transferDetailsResponse =
                    await _feedTransferDetailService.GetFeedTransferDetailsConsolidated(
                        (int)selectedTransfer.IdFeedTransfer
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
                IsRefreshing = false;
            }
        }

        #region Commands

        [RelayCommand]
        async Task GoToPoolTransferDeliveryDetail(
            FeedTransferPoolDetailCustomResponse selectedTransferPoolDetail
        )
        {
            if (selectedTransferPoolDetail == null)
                return;

            await Shell.Current.GoToAsync(
                nameof(PoolTransferDeliveryDetailView),
                true,
                new Dictionary<string, object>
                {
                    { "SelectedTransferPoolDetail", selectedTransferPoolDetail }
                }
            );
        }

        [RelayCommand]
        async Task UpdateStatus()
        {
            try
            {
                IsBusy = true;

                int id = (int)SelectedTransfer.IdFeedTransfer;

                var response = await _feedTransferService.PatchFeedTransferStatus(
                    id,
                    Const.Status.Transfer.InRoute
                );

                if (response != null && response.Code == 200)
                {
                    await ToastService.ShowToastAsync("Estado actualizado exitosamente.");
                    SelectedTransfer.Status = Const.Status.Transfer.InRoute;

                    LoadFeedTransferDetails(id);

                    IsRecieved = false;
                    IsOnRoute = true;
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

        [RelayCommand]
        async Task UpdateDeliveredStatus()
        {
            bool isFinalized = FeedTransferDetails.All(detail =>
                detail.Status == Const.Status.Transfer.Delivered
            );

            if (!isFinalized)
            {
                await ToastService.ShowToastAsync(
                    "Debe entregar todas las piscinas para finalizar el viaje."
                );
                return;
            }

            try
            {
                IsBusy = true;

                int id = (int)SelectedTransfer.IdFeedTransfer;

                var response = await _feedTransferService.PatchFeedTransferStatus(
                    id,
                    Const.Status.Transfer.Delivered
                );

                if (response != null && response.Code == 200)
                {
                    await ToastService.ShowToastAsync("Estado actualizado exitosamente.");
                    SelectedTransfer.Status = Const.Status.Transfer.Delivered;

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

        #endregion
    }
}
