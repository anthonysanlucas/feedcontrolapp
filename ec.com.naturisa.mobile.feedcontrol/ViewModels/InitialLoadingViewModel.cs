namespace ec.com.naturisa.mobile.feedcontrol.ViewModels;

public class InitialLoadingViewModel
{
    private readonly ISubsidiaryUsersService _subsidiaryUsersService;

    public InitialLoadingViewModel(ISubsidiaryUsersService subsidiaryUsersService)
    {
        _subsidiaryUsersService = subsidiaryUsersService;
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

                SubsidiaryUsersQuery subsidiaryUsersQuery = new SubsidiaryUsersQuery
                {
                    UserId = userData.IdUser
                };

                var response = await _subsidiaryUsersService.GetSubsidiaryUsers(subsidiaryUsersQuery);


                await Shell.Current.GoToAsync($"//{nameof(FarmInventoryView)}");

                return;
            }
        }

        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        return;
    }
}
