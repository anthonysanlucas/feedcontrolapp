namespace ec.com.naturisa.mobile.feedcontrol.ViewModels;

public partial class ShellTitleViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<SubsidiaryUserResponse> _availableSubsidiaries;

    [ObservableProperty]
    private SubsidiaryUserResponse _selectedSubsidiary;

    [ObservableProperty]
    private bool _isOpenFarmList;

    public ShellTitleViewModel(IToastService toastService) : base(toastService)
    {
        SelectedSubsidiary = GlobalData.Instance.SelectedSubsidiary;
        AvailableSubsidiaries = GlobalData.Instance.Subsidiaries;
    }

    [RelayCommand]
    async Task OpenSelectFarmView()
    {
        IsOpenFarmList = !IsOpenFarmList;
    }

    [RelayCommand]
    async Task SubsidiarySelected(SubsidiaryUserResponse subsidiary)
    {        
        IsOpenFarmList = false;
        await ToastService.ShowToastAsync($"Has seleccionado {subsidiary.NameSubsidiary}");

        AvailableSubsidiaries = new ObservableCollection<SubsidiaryUserResponse>(
            AvailableSubsidiaries
                .Select(item =>
                {
                    item.IsSelected = item.SubsidiaryId == subsidiary.SubsidiaryId;
                    return item;
                })
        );
     
        OnPropertyChanged(nameof(AvailableSubsidiaries));
    }


    [RelayCommand]
    async Task SelectFarm(SubsidiaryUserResponse subsidiary)
    {
        if (subsidiary != null)
        {
            SelectedSubsidiary = subsidiary;
            await ToastService.ShowToastAsync($"Has seleccionado {subsidiary.NameSubsidiary}");
        }
    }
}
