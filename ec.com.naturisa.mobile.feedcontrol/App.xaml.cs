namespace ec.com.naturisa.mobile.feedcontrol
{
    public partial class App : Application
    {        
        public static UserData? UserData;
        
        public static ObservableCollection<SubsidiaryUserResponse>? Subsidiaries;
     
        public static SubsidiaryUserResponse? SelectedSubsidiary;

        public App(IToastService toastService)
        {
            InitializeComponent();
            MainPage = new AppShell(toastService);
        }
    }
}
