namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class InventoryReceptionViewModel : BaseViewModel
    {
        private readonly FeedTransferService _feedTransferService;

        [ObservableProperty]
        private ObservableCollection<FeedTransferModel> feedingTrips;

        public InventoryReceptionViewModel(IToastService toastService)
            : base(toastService)
        {
            _feedTransferService = new FeedTransferService();

            GetFeedTransfers();
        }

        [RelayCommand]
        async Task CreateTransfer()
        {
            //await Shell.Current.GoToAsync(nameof(NewInventoryReceptionOneStepView));
        }

        [RelayCommand]
        async Task GetFeedTransfers()
        {
            IsNotBusy = false;
            IsBusy = true;
            IsRefreshing = false;

            var response = await _feedTransferService.GetFeedTransfers();

            if (response != null && response.Data != null && response.Data.Data.Any())
            {
                var feedTransferModels = response.Data.Data;

                FeedingTrips = new ObservableCollection<FeedTransferModel>(feedTransferModels);
            }

            IsBusy = false;
            IsNotBusy = true;
        }
    }
}
