namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class PoolTransferViewModel : BaseViewModel
    {
        private readonly FeedTransferService _feedTransferService;

        [ObservableProperty]
        private ObservableCollection<FeedTransferModel> feedingTrips;

        public PoolTransferViewModel(IToastService toastService)
            : base(toastService)
        {
            _feedTransferService = new FeedTransferService();

            GetFeedTransfers();
        }

        [RelayCommand]
        async Task CreateTransfer()
        {
            await Shell.Current.GoToAsync(nameof(NewPoolTransferOneStepView));
        }

        [RelayCommand]
        async Task GoToPoolTransferDetail(FeedTransferModel selectedTransfer)
        {
            if (selectedTransfer == null)
                return;

            await Shell.Current.GoToAsync(
                nameof(PoolTransferDetailView),
                true,
                new Dictionary<string, object> { { "SelectedTransfer", selectedTransfer } }
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
