using DevExpress.Internal;

namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isOpenFarmList = false;
      
        [ObservableProperty]
        private ObservableCollection<SubsidiaryUserResponse> availableSubsidiaries;

        private readonly ISubsidiaryUsersService _subsidiaryUsersService;

        public AppShellViewModel(IToastService toastService)
            : base(toastService) {           

           GetSubsidiaries();
        }
               

        [RelayCommand]
        async Task GetSubsidiaries()
        {
            SubsidiaryUsersQuery subsidiaryUsersQuery = new SubsidiaryUsersQuery
            {
                UserId = App.UserData.IdUser
            };

            var response = await _subsidiaryUsersService.GetSubsidiaryUsers(subsidiaryUsersQuery);

            if (response.Data != null)
            {
                AvailableSubsidiaries = new ObservableCollection<SubsidiaryUserResponse>(response.Data.Data);

                if (Subsidiaries.Count > 0)
                {
                    SelectedSubsidiary = Subsidiaries.FirstOrDefault();
                }
            }
        }
        

        [RelayCommand]
        async Task Logout()
        {
            SecureStorage.Default.RemoveAll();
            Preferences.Default.Clear();

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }

        [RelayCommand]
        async Task OpenNotificationsDetailView()
        {
            await Shell.Current.GoToAsync(nameof(NotificationsDetailView), true);
        }

        

        [RelayCommand]
        async Task OpenProfileDetailView()
        {
            await Shell.Current.GoToAsync(nameof(ProfileDetailView), true);

            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
