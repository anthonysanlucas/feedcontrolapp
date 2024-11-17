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
        // Initialize properties or load data here

        SelectedSubsidiary = App.SelectedSubsidiary;
    }

    [RelayCommand]
    async Task OpenSelectFarmView()
    {
        IsOpenFarmList = !IsOpenFarmList;

        // await Shell.Current.GoToAsync(nameof(SelectFarmView), true);
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
