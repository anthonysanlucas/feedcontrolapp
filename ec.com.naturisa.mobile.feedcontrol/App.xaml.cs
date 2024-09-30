namespace ec.com.naturisa.mobile.feedcontrol
{
    public partial class App : Application
    {
        public App(IToastService toastService)
        {
            InitializeComponent();

            MainPage = new AppShell(toastService);
        }
    }
}
