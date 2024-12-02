namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public partial class PoolTransferTwoStepSelectionModel : ObservableObject
    {
        [ObservableProperty]
        public ProductResponse? selectedProduct;

        [ObservableProperty]
        public PoolsResponse? selectedPool;

        [ObservableProperty]
        public int? quantitySacks;
    }
}
