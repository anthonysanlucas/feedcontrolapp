namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FeedingMovementsViewModel : BaseViewModel
    {
        private readonly IFeedTransferService _feedTransferService;

        [ObservableProperty]
        private ObservableCollection<FeedTransfer> feedTransfers;

        [ObservableProperty]
        private ObservableCollection<FeedTransferModel> feedingTrips;

        public FeedingMovementsViewModel(
            IToastService toastService,
            IFeedTransferService feedTransferService
        )
            : base(toastService)
        {
            _feedTransferService = feedTransferService;

            GetFeedTransfers();
        }

        [RelayCommand]
        async Task GoToPoolFeedingByDay()
        {
            await Shell.Current.GoToAsync(nameof(PoolFeedingByDay));
        }

        [RelayCommand]
        async Task GoToReceptionOfFoodByCarrier(FeedTransfer feedTransfer)
        {
            if (feedTransfer is null)
                return;

            await Shell.Current.GoToAsync(
                nameof(ReceptionOfFoodByCarrier),
                true,
                new Dictionary<string, object> { { "FeedTransfer", feedTransfer } }
            );
        }

        [RelayCommand]
        async Task GetFeedTransfers()
        {
            IsNotBusy = false;
            IsBusy = true;
            IsRefreshing = false;

            try
            {
                var response = await _feedTransferService.GetFeedTransfers();

                if (response != null && response.Data != null && response.Data.Data.Any())
                {
                    var feedTransferModels = response.Data.Data;

                    FeedingTrips = new ObservableCollection<FeedTransferModel>(feedTransferModels);
                }
            }
            catch (Exception ex)
            {
                await ToastService.ShowToastAsync("Ha ocurrido un error, intente nuevamente.");
            }
            finally
            {
                IsBusy = false;
                IsNotBusy = true;
            }
        }
    }
}
