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
            string UserDataString = Preferences.Get(nameof(App.UserData), "");

            if (string.IsNullOrWhiteSpace(UserDataString))
            {
                await Shell.Current.GoToAsync(nameof(LoginView));

                return;
            }

            //{
            //    if (DeviceInfo.Platform == DevicePlatform.WinUI)
            //    {
            //        AppShell.Current.Dispatcher.Dispatch(async () =>
            //        {
            //            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            //        });
            //    }
            //    else
            //    {
            //        //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            //    }
            //    // navigate to Login Page
            //}
            //else
            //{
            //    //var userInfo = JsonConvert.DeserializeObject<UserBasicInfo>(userDetailsStr);
            //    //App.UserDetails = userInfo;
            //    //await AppConstant.AddFlyoutMenusDetails();
            //}
        }
    }
}
