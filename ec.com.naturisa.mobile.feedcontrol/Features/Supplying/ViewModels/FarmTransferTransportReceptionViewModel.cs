namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

public partial class FarmTransferTransportReceptionViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{
    [ObservableProperty]
    private ObservableCollection<WarehouseTransferResponse> warehouseTrips;

    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    [ObservableProperty]
    private WarehouseTransferQuery warehouseTransferQuery;

    private readonly IWarehouseTransferService _warehouseTransferService;

    public FarmTransferTransportReceptionViewModel(IWarehouseTransferService warehouseTransferService, IToastService toastService) : base(toastService)
    {
        _warehouseTransferService = warehouseTransferService;

        FilterStatuses = new ObservableCollection<FilterStatus>
        {
            new FilterStatus { Status = "TODOS", IsSelected = true },
            new FilterStatus { Status = "ASIGNADO" },
            new FilterStatus { Status = "RECIBIDO" },
            new FilterStatus { Status = "EN RUTA" },
            new FilterStatus { Status = "ENTREGADO" }
        };

        WarehouseTransferQuery = new WarehouseTransferQuery
        {
            IncludeDestinationWarehouse = true,
            IncludeOriginWarehouse = true,
            IncludeTransport = true,
            IncludeStatusCatalogue = true,
            IncludeFreightTransporter = true,
        };

        WeakReferenceMessenger.Default.Register<RefreshDataMessage>(this);
        Task.Run(() => GetFarmTransfers());
    }

    #region commands
    [RelayCommand]
    private void SelectFilter(string status)
    {
        foreach (var filter in FilterStatuses)
        {
            filter.IsSelected = filter.Status == status;
        }
    }

    [RelayCommand]
    async Task GetFarmTransfers()
    {
        IsBusy = true;

        try
        {
            var response = await _warehouseTransferService.GetWarehouseTransfers(WarehouseTransferQuery);

            if (response.Data != null && response.Code == 200)
            {
                var warehouseTransferResponses = response.Data.Data;

                WarehouseTrips = new ObservableCollection<WarehouseTransferResponse>(warehouseTransferResponses);
            }
            else
            {
                WarehouseTrips?.Clear();
                await ToastService.ShowToastAsync(response.Message);
            }

        }
        catch (Exception ex)
        {
            await ToastService.ShowToastAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;

        }
    }

    [RelayCommand]
    async Task GoToDetail(WarehouseTransferResponse warehouseTransfer)
    {
        if (warehouseTransfer is null) return;

        await Shell.Current.GoToAsync(nameof(FarmTransferTransportReceptionDetailView),
            true,
             new Dictionary<string, object>
            {{ "WarehouseTransfer", warehouseTransfer }});
    }
    #endregion

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Task.Run(() => GetFarmTransfers());
        });
    }

}