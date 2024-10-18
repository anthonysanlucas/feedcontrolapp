namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
    public partial class PoolTransferReceptionViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferModel selectedTransfer;

        public PoolTransferReceptionViewModel(IToastService toastService)
            : base(toastService) { }
    }
}
