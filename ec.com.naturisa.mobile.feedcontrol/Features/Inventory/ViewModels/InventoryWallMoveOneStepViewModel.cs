namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

public partial class InventoryWallMoveOneStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<TransportResponse> transports;

    [ObservableProperty]
    private ObservableCollection<FreightTransporterResponse> freightTransporters;

    [ObservableProperty]
    private ObservableCollection<PoolsResponse> pools;

    [ObservableProperty]
    private ObservableCollection<PoolsResponse> otherPools;

    [ObservableProperty]
    private TransportResponse selectedTransport;

    [ObservableProperty]
    private FreightTransporterResponse selectedFreightTransporter;

    [ObservableProperty]
    private PoolsResponse selectedPool;

    [ObservableProperty]
    private PoolsResponse selectedOtherPool;

    public InventoryWallMoveOneStepViewModel(IToastService toastService) : base(toastService)
    {
        Transports = new ObservableCollection<TransportResponse>
        {
            new TransportResponse { IdTransport = 10, NumberPlate = "GTN2016" }
        };

        FreightTransporters = new ObservableCollection<FreightTransporterResponse>
        {
            new FreightTransporterResponse { IdFreightTransporter= 16, FirstName = "Nelson", LastName = "Zambrano" },
        };

        Pools = new ObservableCollection<PoolsResponse>
        {
            new PoolsResponse { IdPool = 1, Name = "NA001" },
            new PoolsResponse { IdPool = 2, Name = "NA002" },
            new PoolsResponse { IdPool = 3, Name = "NA003" },
            new PoolsResponse { IdPool = 3, Name = "NA004" },
            new PoolsResponse { IdPool = 3, Name = "NA005" },
            new PoolsResponse { IdPool = 3, Name = "NA006" },
            new PoolsResponse { IdPool = 3, Name = "NA007" },
            new PoolsResponse { IdPool = 3, Name = "NA008" },
            new PoolsResponse { IdPool = 3, Name = "NA010" },
        };

        OtherPools = new ObservableCollection<PoolsResponse>
        {
            new PoolsResponse { IdPool = 2, Name = "NA002" },
            new PoolsResponse { IdPool = 3, Name = "NA003" },
            new PoolsResponse { IdPool = 3, Name = "NA004" },
            new PoolsResponse { IdPool = 3, Name = "NA005" },
            new PoolsResponse { IdPool = 3, Name = "NA006" },
            new PoolsResponse { IdPool = 3, Name = "NA007" },
            new PoolsResponse { IdPool = 3, Name = "NA008" },
            new PoolsResponse { IdPool = 3, Name = "NA009" },
            new PoolsResponse { IdPool = 3, Name = "NA010" },
        };
    }

    [RelayCommand]
    async Task GoToTwoStep()
    {
        await Shell.Current.GoToAsync(nameof(InventoryWallMoveTwoStepView), true, new Dictionary<string, object>
        {
            ["SelectedTransport"] = SelectedTransport,
            ["SelectedFreightTransporter"] = SelectedFreightTransporter,
            ["SelectedPool"] = SelectedPool,
            ["SelectedOtherPool"] = SelectedOtherPool
        });
    }
}
