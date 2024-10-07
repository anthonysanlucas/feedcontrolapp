namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private DateTime _currentDateTime = DateTime.Now;

        // (e.g., 29, September 2024)
        [ObservableProperty]
        private string _longDate;

        // (e.g., 29/09/2024)
        [ObservableProperty]
        private string _shortDate;

        [ObservableProperty]
        private string _shortPreviousDate;

        // (e.g., 14:30)
        [ObservableProperty]
        private string _timeOnly;

        protected IToastService ToastService { get; }

        public BaseViewModel(IToastService toastService)
        {
            ToastService = toastService;
            UpdateDateFormats();
        }

        // Method to show a toast
        protected async Task ShowToastAsync(
            string message,
            ToastDuration duration = ToastDuration.Short,
            double fontSize = 14
        )
        {
            await ToastService.ShowToastAsync(message, duration, fontSize);
        }

        private void UpdateDateFormats()
        {
            LongDate = _currentDateTime.ToString("dd, MMMM yyyy");
            ShortDate = _currentDateTime.ToString("dd/MM/yyyy");
            TimeOnly = _currentDateTime.ToString("HH:mm");
            ShortPreviousDate = _currentDateTime.AddDays(-1).ToString("dd/MM/yyyy");
        }

        partial void OnCurrentDateTimeChanged(DateTime value)
        {
            UpdateDateFormats();
        }
    }
}
