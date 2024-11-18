namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels;

public partial class TransferMovementViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{
    [ObservableProperty]
    private bool isDeliveryView = true;

    [ObservableProperty]
    private bool isReturnView = false;

    [ObservableProperty]
    private ObservableCollection<FeedTransfer> feedTransfers;

    [ObservableProperty]
    private ObservableCollection<FeedTransferModel> feedingTrips;

    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    [ObservableProperty]
    private FeedTransferQuery transferQuery;

    private readonly IFeedTransferService _feedTransferService;

    private readonly IToastService _toastService;

    public TransferMovementViewModel(IFeedTransferService feedTransferService, IToastService toastService) : base(toastService)
    {
        _feedTransferService = feedTransferService;
        _toastService = toastService;

        FilterStatuses = new ObservableCollection<FilterStatus>
        {
            new FilterStatus { Status = "TODOS", IsSelected = true },
            new FilterStatus { Status = "ASIGNADO" },
            new FilterStatus { Status = "RECIBIDO" },
            new FilterStatus { Status = "EN RUTA" },
            new FilterStatus { Status = "ENTREGADO" }
         };

        TransferQuery = new FeedTransferQuery()
        {
            Type = Const.Types.FeedTransferType.Delivery
        };

        GetFeedTransfers();
    }

    #region commands

    [RelayCommand]
    private void SelectDelivery()
    {
        if (IsDeliveryView)
            return;

        IsDeliveryView = true;
        IsReturnView = false;

        TransferQuery.Type = Const.Types.FeedTransferType.Delivery;

        GetFeedTransfers();
    }

    [RelayCommand]
    private void SelectReturn()
    {
        if (IsReturnView)
            return;

        IsReturnView = true;
        IsDeliveryView = false;

        TransferQuery.Type = Const.Types.FeedTransferType.Return;
        GetFeedTransfers();
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
    async Task GoToPoolFeedingByDay()
    {
        await Shell.Current.GoToAsync(nameof(PoolFeedingByDay));
    }

    [RelayCommand]
    async Task GoToPoolTransferReception(FeedTransferModel selectedTransfer)
    {
        if (selectedTransfer == null)
            return;

        if (selectedTransfer.Type == Const.Types.FeedTransferType.Return)
        {
            await Shell.Current.GoToAsync(nameof(TransferMovementReturnView), true, new Dictionary<string, object> { { "SelectedTransfer", selectedTransfer } });
            return;
        }

        if (selectedTransfer.Status == Const.Status.Transfer.Assigned)
            await Shell.Current.GoToAsync(
                nameof(PoolTransferReceptionView),
                true,
                new Dictionary<string, object> { { "SelectedTransfer", selectedTransfer } }
            );

        if (
            selectedTransfer.Status == Const.Status.Transfer.Received
            || selectedTransfer.Status == Const.Status.Transfer.InRoute
            || selectedTransfer.Status == Const.Status.Transfer.Delivered
        )
            await Shell.Current.GoToAsync(
                nameof(StartOfRouteView),
                true,
                new Dictionary<string, object> { { "SelectedTransfer", selectedTransfer } }
            );
    }

    [RelayCommand]
    async Task GetFeedTransfers()
    {
        IsNotBusy = false;
        IsBusy = true;
        IsRefreshing = false;

        try
        {
            var response = await _feedTransferService.GetFeedTransfers(TransferQuery);

            if (response != null && response.Data != null && response.Data.Data.Any())
            {
                var feedTransferModels = response.Data.Data;

                FeedingTrips = new ObservableCollection<FeedTransferModel>(feedTransferModels);
            }
            else
            {
                FeedingTrips?.Clear();
            }
        }
        catch (Exception ex)
        {
            await ToastService.ShowToastAsync("Ha ocurrido un error, intente nuevamente.");
        }
        finally
        {
            IsBusy = false;
            IsNotBusy = true;
        }
    }

    #endregion

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            GetFeedTransfers();
        });
    }
}
