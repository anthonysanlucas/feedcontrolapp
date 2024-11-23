namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
    public partial class PoolTransferDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferModel selectedTransfer;

        [ObservableProperty]
        private FeedTransferDetailCustomResponseModel selectedTransferDetail;

        [ObservableProperty]
        private ObservableCollection<FeedTransferPoolDetailCustomResponse> feedTransferDetails;

        [ObservableProperty]
        private ObservableCollection<FilterStatus> filterStatuses;

        [ObservableProperty]
        private bool isTableView = true;

        [ObservableProperty]
        private bool isPoolView = false;

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

            FilterStatuses = new ObservableCollection<FilterStatus>
            {
                new FilterStatus { Status = "TABLA", IsSelected= true},
                new FilterStatus { Status = "PISCINA" },                
            };
        }

        [RelayCommand]
        private void SelectFilter(string status)
        {
            foreach (var filter in FilterStatuses)
            {
                filter.IsSelected = filter.Status == status;
            }

            if(status == "TABLA")
            {
                IsTableView = true;
                IsPoolView = false;
            }
            else
            {
                IsTableView = false;
                IsPoolView = true;
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

        [RelayCommand]
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

        [RelayCommand]
        async Task ShowPoolDetail()
        {
            
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
