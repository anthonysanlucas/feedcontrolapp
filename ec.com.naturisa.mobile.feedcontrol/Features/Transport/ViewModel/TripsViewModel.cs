namespace ec.com.naturisa.mobile.feedcontrol.Features.Transport.ViewModel;

public partial class TripsViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{
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
            AssignmentDate = new DateTime(2024, 11, 22),
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
                //TripResponse = new ObservableCollection<UnifiedTripResponse>((IEnumerable<UnifiedTripResponse>)trips.Data);
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

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            //GetFeedTransfers();
        });
    }
}
