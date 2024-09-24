namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class AppShellViewModel
    {
        public AppShellViewModel() { }

        [RelayCommand]
        async Task Logout()
        {
            // Delete the token from the secure storage and navigate to the login page

            // await Shell.Current.GoToAsync($"/{nameof(LoginView)}");
        }

        [RelayCommand]
        async Task OpenNotificationsDetailView()
        {
            await Shell.Current.GoToAsync(nameof(NotificationsDetailView), true);
        }

        [RelayCommand]
        async Task OpenSelectFarmView()
        {
            await Shell.Current.GoToAsync(nameof(SelectFarmView), true);
        }

        [RelayCommand]
        async Task OpenProfileDetailView()
        {
            await Shell.Current.GoToAsync(nameof(ProfileDetailView), true);

            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
