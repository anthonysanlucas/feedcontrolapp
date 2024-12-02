namespace ec.com.naturisa.mobile.feedcontrol.Features.Transport.ViewModel;

public partial class TripsViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{
    [ObservableProperty]
    private bool isDeliveryView = true;

    [ObservableProperty]
    private bool isReturnView = false;

    [ObservableProperty]
    private ObservableCollection<FeedTransferModel> feedingTrips;

    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    [ObservableProperty]
    private ObservableCollection<UnifiedTripResponse> tripResponse;

    [ObservableProperty]
    private ObservableCollection<UnifiedTransfer> transfers;

    [ObservableProperty]
    private UnifiedTripQuery tripQuery;

    private readonly IFreightTransporterService _freightTransporterService;

    public TripsViewModel(IToastService toastService, IFreightTransporterService freightTransporterService) : base(toastService)
    {
        _freightTransporterService = freightTransporterService;
        WeakReferenceMessenger.Default.Register<RefreshDataMessage>(this);

        Transfers = new ObservableCollection<UnifiedTransfer>();

        TripQuery = new UnifiedTripQuery
        {
            AssignmentDate = DateTime.Now,
            IncludeFreightTransporter = true,
            IncludeTransport = true,
            IncludeSupplier = true,
            IncludeWarehouse = true,
            IncludeSupplierTransferDetails = true,
            IncludeStatusCatalogue = true,
            FreightTransporterUserId = GlobalData.Instance.UserData.IdUser,
            StatusCatalogueName = [Const.Status.Transfer.Assigned, Const.Status.Transfer.Received, Const.Status.Transfer.InRoute, Const.Status.Transfer.Paused, Const.Status.Transfer.AtDestination, Const.Status.Transfer.Delivered],
            Type = Const.Types.FeedTransferType.Delivery,
            IncludeStatusCatalogueList = true
        };

        FilterStatuses = new ObservableCollection<FilterStatus>
        {
            new FilterStatus { Status = "TODOS", IsSelected = true },
            new FilterStatus { Status = "ASIGNADO" },
            new FilterStatus { Status = "RECIBIDO" },
            new FilterStatus { Status = "EN RUTA" },
            new FilterStatus { Status = "ENTREGADO" }
        };

        Task.Run(() => GetTrips());
    }

    [RelayCommand]
    private void SelectDelivery()
    {
        if (IsDeliveryView)
            return;

        IsDeliveryView = true;
        IsReturnView = false;

        TripQuery.Type = Const.Types.FeedTransferType.Delivery;

        Task.Run(() => GetTrips());
    }

    [RelayCommand]
    private void SelectReturn()
    {
        if (IsReturnView)
            return;

        IsReturnView = true;
        IsDeliveryView = false;

        TripQuery.Type = Const.Types.FeedTransferType.Return;
        Task.Run(() => GetTrips());
    }

    [RelayCommand]
    private void SelectFilter(string status)
    {
        foreach (var filter in FilterStatuses)
        {
            filter.IsSelected = filter.Status == status;
        }
    }

    [RelayCommand]
    async Task GetTrips()
    {
        IsBusy = true;

        try
        {
            var trips = await _freightTransporterService.GetTrips(TripQuery);

            if (trips != null)
            {
                Transfers = new ObservableCollection<UnifiedTransfer>(trips);
            }
        }
        catch (Exception ex)
        {
            await ShowToastAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToDetail(UnifiedTransfer unifiedTransfer)
    {
        if (unifiedTransfer == null)
            return;

        if (unifiedTransfer.TransferType == Const.Types.UnifiedTrip.WarehouseTransfer)
        {
            try
            {
                var warehouseTransferResponse = (WarehouseTransferResponse)unifiedTransfer.OriginalData;

                await Shell.Current.GoToAsync(nameof(FarmTransferTransportDetailView),
                    true,
                    new Dictionary<string, object> { { "WarehouseTransfer", warehouseTransferResponse } });
            }
            catch (InvalidCastException)
            {
                await ShowToastAsync("Error: Tipo de transferencia no válido para WarehouseTransfer.");
            }
        }

        if (unifiedTransfer.TransferType == Const.Types.UnifiedTrip.FeedTransfer)
        {
            var feedTransferResponse = (FeedTransferModel)unifiedTransfer.OriginalData;

            if (feedTransferResponse.Type == Const.Types.FeedTransferType.Return)
            {
                await Shell.Current.GoToAsync(nameof(TransferMovementReturnView), true, new Dictionary<string, object> { { "SelectedTransfer", feedTransferResponse } });
                return;
            }

            if (feedTransferResponse.Status == Const.Status.Transfer.Assigned) { 
                await Shell.Current.GoToAsync(
                    nameof(PoolTransferReceptionView),
                    true,
                    new Dictionary<string, object> { { "SelectedTransfer", feedTransferResponse } }
                );
                return;
            }

            if (
                feedTransferResponse.Status == Const.Status.Transfer.Received
                || feedTransferResponse.Status == Const.Status.Transfer.InRoute
                || feedTransferResponse.Status == Const.Status.Transfer.Delivered
            )
            {
                await Shell.Current.GoToAsync(
                    nameof(StartOfRouteView),
                    true,
                    new Dictionary<string, object> { { "SelectedTransfer", feedTransferResponse } }
                );
                return;
            }
        }

        if (unifiedTransfer.TransferType == Const.Types.UnifiedTrip.PoolTransfer)
        {

        }
    }

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Task.Run(() => GetTrips());
        });
    }
}
