using ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

public partial class FarmTransferViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{

    [ObservableProperty]
    private ObservableCollection<WarehouseTransferResponse> feedingTrips;

    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    [ObservableProperty]
    private WarehouseTransferQuery warehouseTransferQuery;

    private readonly IWarehouseTransferService _warehouseTransferService;

    public FarmTransferViewModel(IWarehouseTransferService warehouseTransferService, IToastService toastService)
        : base(toastService)
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

        GetFarmTransfers();
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

                FeedingTrips = new ObservableCollection<WarehouseTransferResponse>(warehouseTransferResponses);
            }
            else
            {
                FeedingTrips?.Clear();
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
    async Task CreateTransfer()
    {
        await Shell.Current.GoToAsync(nameof(NewTransferOneStepView));
    }
    #endregion


    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            GetFarmTransfers();
        });
    }
}
