namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels;

public partial class NewTransferOneStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private WarehouseTransferRequest warehouseTransfer;

    [ObservableProperty]
    private int originWarehouseId = 64;

    [ObservableProperty]
    private ObservableCollection<WarehouseResponse> warehouses;

    [ObservableProperty]
    private WarehouseResponse originWarehouse;

    [ObservableProperty]
    private List<string> destinationBranches;

    [ObservableProperty]
    private List<string> destinations;

    [ObservableProperty]
    private List<string> transporters;

    [ObservableProperty]
    private ObservableCollection<TransportResponse> transports;

    [ObservableProperty]
    private ObservableCollection<FreightTransporterResponse> freightTransporters;    

    [ObservableProperty]
    private string selectedOriginWharehouse;

    [ObservableProperty]
    private string selectedDestinationBranch;

    [ObservableProperty]
    private WarehouseResponse destinationWarehouse;

    [ObservableProperty]
    private TransportResponse selectedTransport;

    [ObservableProperty]
    private FreightTransporterResponse selectedFreightTransporter;    

    private readonly IWarehouseService _warehouseService;

    private readonly ITransportService _transportService;

    private readonly IFreightTransporterService _freightTransporterService;

    public NewTransferOneStepViewModel(ITransportService transportService, IWarehouseService warehouseService, IFreightTransporterService freightTransporterService, IToastService toastService)
        : base(toastService)
    {
        _warehouseService = warehouseService;
        _transportService = transportService;
        _freightTransporterService = freightTransporterService;

        Task.Run(() => GetWarehouses());
        Task.Run(() => GetTransports());
        Task.Run(() => GetFreightTransporters());

        OriginWarehouse = new WarehouseResponse
        {
            IdWarehouse = 64,
            Name = "Acopio Pezjoya"
        };

        destinationBranches = ["Naturisa"];        
    }

    #region commands        
    [RelayCommand]
    async Task GoToTwoStep()
    {
        // if (
        //    string.IsNullOrEmpty(SelectedDestinationBranch)
        //    || string.IsNullOrEmpty(SelectedTransporter)
        //    || string.IsNullOrEmpty(SelectedVehiclePlate)
        //)
        // {
        //     await ToastService.ShowToastAsync("Por favor complete todos los campos");
        //     return;
        // }

        WarehouseTransfer = new WarehouseTransferRequest
        {
            OriginWarehouseId = OriginWarehouse.IdWarehouse,
            DestinationWarehouseId = DestinationWarehouse.IdWarehouse            
        };

        await Shell.Current.GoToAsync(nameof(NewTransferTwoStepView),
            true,
            new Dictionary<string, object>
            {
                ["WarehouseTransfer"] = WarehouseTransfer,
                ["OriginWarehouse"] = OriginWarehouse,
                ["DestinationWarehouse"] = DestinationWarehouse,
                ["SelectedTransport"] = SelectedTransport,
                ["SelectedFreightTransporter"] = SelectedFreightTransporter
            }
            );
    }
    #endregion

    async Task GetWarehouses()
    {
        WarehouseQuery warehouseQuery = new() { };

        var response = await _warehouseService.GetWarehouses(warehouseQuery);

        if (response.Data != null && response.Code == 200)
        {
            Warehouses = new ObservableCollection<WarehouseResponse>(response.Data.Data);
        }
        else
        {
            await ShowToastAsync(response.Message ?? "Ha ocurrido un error al cargar las bodegas");
        }
    }

    async Task GetTransports()
    {
        TransportQuery transportQuery = new() { };

        var response = await _transportService.GetTransports(transportQuery);

        if (response.Data != null && response.Code == 200)
        {
            Transports = new ObservableCollection<TransportResponse>(response.Data.Data);
        }
        else
        {
            await ShowToastAsync(response.Message ?? "Ha ocurrido un error al cargar los transportes");
        }
    }

    async Task GetFreightTransporters()
    {
        FreightTransporterQuery freightTransporterQuery = new() { };

        var response = await _freightTransporterService.GetFreightTransporters(freightTransporterQuery);

        if (response.Data != null && response.Code == 200)
        {
            FreightTransporters = new ObservableCollection<FreightTransporterResponse>(response.Data.Data);
        }
        else
        {
            await ShowToastAsync(response.Message ?? "Ha ocurrido un error al cargar los transportistas");
        }
    }
}