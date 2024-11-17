namespace ec.com.naturisa.mobile.feedcontrol.Models;

public partial class GlobalData : ObservableObject
{
    private static readonly Lazy<GlobalData> _instance = new(() => new GlobalData());

    public static GlobalData Instance => _instance.Value;

    [ObservableProperty]
    private UserData? userData;

    [ObservableProperty]
    private ObservableCollection<SubsidiaryUserResponse> subsidiaries;

    [ObservableProperty]
    private SubsidiaryUserResponse? selectedSubsidiary;

    private GlobalData()
    {
        Subsidiaries = new ObservableCollection<SubsidiaryUserResponse>();
    }
     
    public async Task LoadDataAsync(ISubsidiaryUsersService subsidiaryUsersService, IToastService toastService)
    {
        try
        {
            // Recuperar datos del usuario desde las preferencias
            string userDataString = Preferences.Get(nameof(UserData), string.Empty);

            if (string.IsNullOrWhiteSpace(userDataString))
            {
                await toastService.ShowToastAsync("Usuario no autenticado. Redirigiendo al inicio de sesión.");
                return;
            }

            // Deserializar el usuario
            UserData? user = JsonSerializer.Deserialize<UserData>(userDataString);

            if (user != null)
            {
                UserData = user;

                // Consulta para obtener las subsidiarias
                SubsidiaryUsersQuery subsidiaryUsersQuery = new SubsidiaryUsersQuery
                {
                    UserId = user.IdUser
                };

                var response = await subsidiaryUsersService.GetSubsidiaryUsers(subsidiaryUsersQuery);

                if (response?.Data?.Data != null)
                {
                    Subsidiaries = new ObservableCollection<SubsidiaryUserResponse>(response.Data.Data);
                    SelectedSubsidiary = Subsidiaries.FirstOrDefault();
                    SelectedSubsidiary.IsSelected = true;
                }
                else
                {
                    await toastService.ShowToastAsync("No se encontraron datos de subsidiarias.", ToastDuration.Long);
                }
            }
            else
            {
                await toastService.ShowToastAsync("Error al cargar los datos del usuario.", ToastDuration.Long);
            }
        }
        catch (Exception ex)
        {
            await toastService.ShowToastAsync($"Error al cargar datos globales: {ex.Message}", ToastDuration.Long);
        }
    }
}
