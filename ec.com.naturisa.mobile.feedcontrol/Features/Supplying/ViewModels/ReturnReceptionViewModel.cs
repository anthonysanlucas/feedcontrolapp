namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

public partial class ReturnReceptionViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<FilterStatus> filterStatuses;

    public ReturnReceptionViewModel(IToastService toastService) : base(toastService)
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

    [RelayCommand]
    private void SelectFilter(string status)
    {
        foreach (var filter in FilterStatuses)
        {
            filter.IsSelected = filter.Status == status;
        }
    }
}
