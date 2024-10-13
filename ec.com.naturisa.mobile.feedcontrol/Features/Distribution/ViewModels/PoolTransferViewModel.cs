using ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer;

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
        async Task GetFeedTransfers()
        {
            var response = await _feedTransferService.GetFeedTransfers();

            if (response != null && response.Data != null && response.Data.Data.Any())
            {
                var feedTransferModels = response.Data.Data;

                FeedingTrips = new ObservableCollection<FeedTransferModel>(feedTransferModels);

                Console.WriteLine($"Número de transferencias: {feedTransferModels.Count}");
            }
            else
            {
                Console.WriteLine("No se recibieron datos de transferencias o hubo un error.");
            }
        }
    }
}
