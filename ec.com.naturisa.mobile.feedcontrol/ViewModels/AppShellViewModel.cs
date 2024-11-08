﻿namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel(IToastService toastService)
            : base(toastService) { }

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
