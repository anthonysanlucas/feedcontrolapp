namespace ec.com.naturisa.mobile.feedcontrol
{
    public partial class App : Application
    {
        public static User? UserData;

        public static ObservableCollection<SubsidiaryUserResponse>? Subsidiaries { get; set; }

        public static SubsidiaryUserResponse? SelectedSubsidiary { get; set; }

        public App(IToastService toastService)
        {
            InitializeComponent();
            MainPage = new AppShell(toastService);
        }
    }
}
