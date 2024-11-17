namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

public partial class ReturnReceptionViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    [ObservableProperty]
    private ObservableCollection<FeedTransferModel> returns;

    [ObservableProperty]
    private FeedTransferQuery transferQuery;

    private readonly IFeedTransferService _feedTransferService;

    public ReturnReceptionViewModel(IFeedTransferService feedTransferService, IToastService toastService) : base(toastService)
    {
        _feedTransferService = feedTransferService;

        TransferQuery = new FeedTransferQuery
        {
            Type = Const.Types.FeedTransferType.Return
        };

        FilterStatuses = new ObservableCollection<FilterStatus>
        {
            new FilterStatus { Status = "TODOS", IsSelected = true },
            new FilterStatus { Status = "ASIGNADO" },
            new FilterStatus { Status = "RECIBIDO" },
            new FilterStatus { Status = "EN RUTA" },
            new FilterStatus { Status = "ENTREGADO" }
        };

        GetReturns();
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
    async Task GetReturns()
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

                Returns = new ObservableCollection<FeedTransferModel>(feedTransferModels);
            }
            else
            {
                Returns?.Clear();
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
}
