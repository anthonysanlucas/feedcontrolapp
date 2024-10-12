namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public class InitialLoadingViewModel
    {
        public InitialLoadingViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {
            string UserData = Preferences.Get(nameof(App.UserData), String.Empty);

            if (!string.IsNullOrWhiteSpace(UserData))
            {
                User? userData = JsonSerializer.Deserialize<User>(UserData);

                // TODO: Check the token expiration (one hour)

                if (userData != null)
                {
                    App.UserData = userData;
                    await Shell.Current.GoToAsync($"//{nameof(FeedingPoolView)}");

                    return;
                }
            }

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");

            return;
        }
    }
}
