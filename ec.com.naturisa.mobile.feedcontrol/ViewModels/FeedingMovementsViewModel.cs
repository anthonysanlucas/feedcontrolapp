namespace ec.com.naturisa.mobile.feedcontrol.ViewModels;

public partial class FeedingMovementsViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{
    private readonly IFeedTransferService _feedTransferService;

    [ObservableProperty]
    private ObservableCollection<FeedTransfer> feedTransfers;

    [ObservableProperty]
    private ObservableCollection<FeedTransferModel> feedingTrips;

    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    public FeedingMovementsViewModel(
        IToastService toastService,
        IFeedTransferService feedTransferService
    )
        : base(toastService)
    {
        _feedTransferService = feedTransferService;

        WeakReferenceMessenger.Default.Register<RefreshDataMessage>(this);

        GetFeedTransfers();

        FilterStatuses = new ObservableCollection<FilterStatus>
        {
            new FilterStatus { Status = "TODOS", IsSelected = true },
            new FilterStatus { Status = "ASIGNADO" },
            new FilterStatus { Status = "RECIBIDO" },
            new FilterStatus { Status = "EN RUTA" },
            new FilterStatus { Status = "ENTREGADO" }           
         };
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
            var response = await _feedTransferService.GetFeedTransfers();

            if (response != null && response.Data != null && response.Data.Data.Any())
            {
                var feedTransferModels = response.Data.Data;

                FeedingTrips = new ObservableCollection<FeedTransferModel>(feedTransferModels);
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

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            GetFeedTransfers();
        });
    }
}
