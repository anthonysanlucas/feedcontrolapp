namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public partial class PoolTransferTwoStepSelectionModel : ObservableObject
    {
        [ObservableProperty]
        public FeedTransferDetailModel? selectedProduct;

        [ObservableProperty]
        public FeedTransferDetailPoolModel? selectedPool;

        [ObservableProperty]
        public int? quantitySacks;
    }
}
