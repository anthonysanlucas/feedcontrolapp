namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private DateTime _currentDateTime = DateTime.Now;

        // Long date format without time (e.g., 29, September 2024)
        [ObservableProperty]
        private string _longDate;

        // Short date format (e.g., 29/09/2024)
        [ObservableProperty]
        private string _shortDate;

        // Time only (e.g., 14:30)
        [ObservableProperty]
        private string _timeOnly;

        protected IToastService ToastService { get; }

        public BaseViewModel(IToastService toastService)
        {
            ToastService = toastService;
            // Initial update for the date formats
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

        // This method updates the date formats based on _currentDateTime
        private void UpdateDateFormats()
        {
            LongDate = _currentDateTime.ToString("dd, MMMM yyyy");
            ShortDate = _currentDateTime.ToString("dd/MM/yyyy");
            TimeOnly = _currentDateTime.ToString("HH:mm");
        }

        // Partial method called whenever CurrentDateTime is updated
        partial void OnCurrentDateTimeChanged(DateTime value)
        {
            // Update the date formats when _currentDateTime changes
            UpdateDateFormats();
        }
    }
}
