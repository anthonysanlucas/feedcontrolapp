using ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class PoolTransferViewModel : BaseViewModel
    {
        private readonly FeedTransferService _feedTransferService;

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
            await _feedTransferService.GetFeedTransfers();
        }
    }
}
