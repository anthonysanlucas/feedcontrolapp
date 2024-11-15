using ec.com.naturisa.mobile.feedcontrol.Controls;

namespace ec.com.naturisa.mobile.feedcontrol.ViewModels;

public class InitialLoadingViewModel : BaseViewModel
{
    private readonly ISubsidiaryUsersService _subsidiaryUsersService;
    private readonly IToastService _toastService;

    public InitialLoadingViewModel(IToastService toastService, ISubsidiaryUsersService subsidiaryUsersService) : base(toastService)
    {
        _subsidiaryUsersService = subsidiaryUsersService;
        _toastService = toastService;

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

                if (response.Data != null)
                {
                    //App.Subsidiaries = new ObservableCollection<SubsidiaryUserResponse>(response.Data.Data);

                    App.Subsidiaries = new ObservableCollection<SubsidiaryUserResponse>(response.Data.Data);

                    if (Subsidiaries.Count > 0)
                    {
                        App.SelectedSubsidiary = Subsidiaries.FirstOrDefault();
                    }

                    ShellTitleViewModel shellTitleViewModel = new ShellTitleViewModel(_toastService);
                    Shell.SetTitleView(Shell.Current, new ShellTitleView(shellTitleViewModel));

                    await Shell.Current.GoToAsync($"//{nameof(FarmInventoryView)}");

                }

                return;
            }
        }

        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        return;
    }
}
