namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

public partial class InventoryWallMoveOneStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<TransportResponse> transports;

    [ObservableProperty]
    private ObservableCollection<FreightTransporterResponse> freightTransporters;

    [ObservableProperty]
    private ObservableCollection<PoolsResponse> pools;

    public InventoryWallMoveOneStepViewModel(IToastService toastService) : base(toastService)
    {        
        Transports = new ObservableCollection<TransportResponse>
        {
            new TransportResponse { NumberPlate = "GTX 213" },
            new TransportResponse { NumberPlate = "GTX 213" },
            new TransportResponse { NumberPlate = "GTX" }
        };

        FreightTransporters = new ObservableCollection<FreightTransporterResponse>
        {
            new FreightTransporterResponse { FirstName = "Nelson", LastName = "Zambrano" },
            new FreightTransporterResponse {FirstName = "Nelson", LastName = "Zambrano"},
            new FreightTransporterResponse { FirstName = "Nelson", LastName = "Zambrano" }
        };

        Pools = new ObservableCollection<PoolsResponse>
        {
            new PoolsResponse { IdPool = 1, Name = "NA001" },
            new PoolsResponse { IdPool = 2, Name = "NA002" },
            new PoolsResponse { IdPool = 3, Name = "NA003" }
        };
    }
}
