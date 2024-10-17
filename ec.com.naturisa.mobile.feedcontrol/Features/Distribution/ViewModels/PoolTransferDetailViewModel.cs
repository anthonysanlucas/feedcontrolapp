namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
    public partial class PoolTransferDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferModel selectedTransfer;

        [ObservableProperty]
        private ObservableCollection<FeedTransferDetailModel> feedTransferDetails;

        [ObservableProperty]
        private int totalSacks;

        [ObservableProperty]
        private int totalPallets;

        [ObservableProperty]
        private bool detailEditable = false;

        private readonly IFeedTransferDetailService _feedTransferDetailService;

        public PoolTransferDetailViewModel(
            IToastService toastService,
            IFeedTransferDetailService feedTransferDetailService
        )
            : base(toastService)
        {
            _feedTransferDetailService = feedTransferDetailService;
        }

        partial void OnSelectedTransferChanged(FeedTransferModel value)
        {
            if (value != null)
            {
                LoadFeedTransferDetails((int)value.IdFeedTransfer);
            }
        }

        private async void LoadFeedTransferDetails(int feedTransferId)
        {
            try
            {
                IsBusy = true;
                var transferDetailsResponse =
                    await _feedTransferDetailService.GetFeedTransferDetails(feedTransferId);

                if (transferDetailsResponse == null || transferDetailsResponse.Code != 200)
                {
                    await ToastService.ShowToastAsync("Error al cargar los detalles del viaje.");
                    return;
                }

                FeedTransferDetails = new ObservableCollection<FeedTransferDetailModel>(
                    transferDetailsResponse.Data.Data
                );
                CalculateTotals();
                IsDetailEditable();
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

        private void CalculateTotals()
        {
            TotalSacks = FeedTransferDetails.Sum(detail => detail.QuantitySacks);
            TotalPallets = (int)Math.Ceiling((double)TotalSacks / 66);
        }

        private void IsDetailEditable()
        {
            if (SelectedTransfer.Status == "ASIGNADO")
            {
                DetailEditable = true;
            }
        }
    }
}
