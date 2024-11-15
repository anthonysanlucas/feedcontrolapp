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
        IsBusy = true;

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

                try
                {
                    var response = await _subsidiaryUsersService.GetSubsidiaryUsers(subsidiaryUsersQuery);

                    if (response.Data != null)
                    {
                        App.Subsidiaries = new ObservableCollection<SubsidiaryUserResponse>(response.Data.Data);

                        if (App.Subsidiaries.Count > 0)
                        {
                            App.SelectedSubsidiary = App.Subsidiaries.FirstOrDefault();
                        }                        
                    }
                    else
                    {
                        await _toastService.ShowToastAsync("No subsidiary data found.", ToastDuration.Long);
                    }                   
                }
                catch (Exception ex)
                {
                    await _toastService.ShowToastAsync($"Error fetching subsidiary users: {ex.Message}", ToastDuration.Long);
                }
                finally
                {
                    ShellTitleViewModel shellTitleViewModel = new ShellTitleViewModel(_toastService);
                    Shell.SetTitleView(Shell.Current, new ShellTitleView(shellTitleViewModel));

                    await Shell.Current.GoToAsync($"//{nameof(FarmInventoryView)}");

                    IsBusy = false;
                }

                return;
            }
        }

        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        IsBusy = false;
    }

}
