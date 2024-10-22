namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransferPoolDetail), nameof(SelectedTransferPoolDetail))]
    public partial class PoolTransferDeliveryDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferPoolDetailCustomResponse selectedTransferPoolDetail;

        public PoolTransferDeliveryDetailViewModel(IToastService toastService)
            : base(toastService) { }
    }
}
