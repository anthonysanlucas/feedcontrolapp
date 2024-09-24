namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        protected IToastService ToastService { get; }

        public BaseViewModel(IToastService toastService)
        {
            ToastService = toastService;
        }

        protected async Task ShowToastAsync(
            string message,
            ToastDuration duration = ToastDuration.Short,
            double fontSize = 14
        )
        {
            await ToastService.ShowToastAsync(message, duration, fontSize);
        }
    }
}
