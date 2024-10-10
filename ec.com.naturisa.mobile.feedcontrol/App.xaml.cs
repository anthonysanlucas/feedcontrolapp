namespace ec.com.naturisa.mobile.feedcontrol
{
    public partial class App : Application
    {
        public static User UserData;

        public App(IToastService toastService)
        {
            InitializeComponent();
            MainPage = new AppShell(toastService);
        }
    }
}
