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

        await GlobalData.Instance.LoadDataAsync(_subsidiaryUsersService, _toastService);

        if (GlobalData.Instance.UserData != null)
        {
            // Configurar la vista del título en el Shell
            ShellTitleViewModel shellTitleViewModel = new ShellTitleViewModel(_toastService);
            Shell.SetTitleView(Shell.Current, new ShellTitleView(shellTitleViewModel));

            // Navegar a la vista principal
            await Shell.Current.GoToAsync($"//{nameof(FarmInventoryView)}");
        }
        else
        {
            // Si no hay datos del usuario, redirigir al inicio de sesión
            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }
       
        IsBusy = false;
    }

}
