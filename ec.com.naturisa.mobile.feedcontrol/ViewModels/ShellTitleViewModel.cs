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
        SelectedSubsidiary = App.SelectedSubsidiary;

        AvailableSubsidiaries = new ObservableCollection<SubsidiaryUserResponse>(App.Subsidiaries);
    }

    [RelayCommand]
    async Task OpenSelectFarmView()
    {
        IsOpenFarmList = !IsOpenFarmList;       
    }

    [RelayCommand]
    async Task SubsidiarySelected(SubsidiaryUserResponse subsidiary)
    {
        foreach (var item in AvailableSubsidiaries)
        {
            if (item.SubsidiaryId == subsidiary.SubsidiaryId)
            {
                item.IsSelected = true;

                await ToastService.ShowToastAsync($"Has seleccionado {subsidiary.NameSubsidiary}");

                IsOpenFarmList = false;

                return;
            }

            item.IsSelected = false;

            return;
        }        
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
