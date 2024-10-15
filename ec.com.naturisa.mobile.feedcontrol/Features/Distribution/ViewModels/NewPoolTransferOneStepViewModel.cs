namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewPoolTransferOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<string> availablePools;

        [ObservableProperty]
        private string originBranch;

        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private List<WarehouseModel> originWarehouses;

        [ObservableProperty]
        private List<CarrierModel> carriers;

        [ObservableProperty]
        private List<TransportModel> transports;

        [ObservableProperty]
        private WarehouseModel selectedOriginWharehouse;

        [ObservableProperty]
        private CarrierModel selectedCarrier;

        [ObservableProperty]
        private TransportModel selectedTransport;

        public NewPoolTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            OriginBranch = "MARICULTURA";

            OriginWarehouses = new List<WarehouseModel>
            {
                new WarehouseModel { Id = 1, Name = "Bodega de Balanceado" }
            };

            Carriers = new List<CarrierModel>
            {
                new CarrierModel { Id = 16, Name = "Nelson Zambrano" }
            };

            Transports = new List<TransportModel>
            {
                new TransportModel { Id = 10, Plate = "GCT5936" }
            };

            SelectedOriginWharehouse = OriginWarehouses.FirstOrDefault();
        }

        [RelayCommand]
        async Task GoToPoolTransferTwoStep()
        {
            PoolTransferOneStepSelection = new()
            {
                OriginBranch = OriginBranch,
                SelectedWarehouse = SelectedOriginWharehouse,
                SelectedCarrier = SelectedCarrier,
                SelectedTransport = SelectedTransport
            };

            await Shell.Current.GoToAsync(
                nameof(NewPoolTransferTwoStepView),
                true,
                new Dictionary<string, object>
                {
                    ["PoolTransferOneStepSelection"] = PoolTransferOneStepSelection,
                }
            );
        }

        private void SortAvailablePools()
        {
            var sortedPools = AvailablePools.OrderBy(p => p).ToList();

            AvailablePools.Clear();
            foreach (var pool in sortedPools)
            {
                AvailablePools.Add(pool);
            }
        }
    }
}
