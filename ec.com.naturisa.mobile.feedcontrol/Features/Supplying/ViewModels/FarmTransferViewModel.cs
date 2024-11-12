namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

public partial class FarmTransferViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{

    private readonly FeedTransferService _feedTransferService;

    [ObservableProperty]
    private ObservableCollection<FeedTransferModel> feedingTrips;

    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    public FarmTransferViewModel(IToastService toastService)
        : base(toastService)
    {
        FilterStatuses = new ObservableCollection<FilterStatus>
        {
            new FilterStatus { Status = "TODOS", IsSelected = true },
            new FilterStatus { Status = "ASIGNADO" },
            new FilterStatus { Status = "RECIBIDO" },
            new FilterStatus { Status = "EN RUTA" },
            new FilterStatus { Status = "ENTREGADO" }
        };
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
    async Task CreateTransfer()
    {
        await Shell.Current.GoToAsync(nameof(NewTransferOneStepView));
    }
    #endregion

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
           // GetFeedTransfers();
        });
    }
}
