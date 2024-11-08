﻿namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private bool _isNotBusy;

        [ObservableProperty]
        private DateTime _currentDateTime = DateTime.Now;

        // (e.g., 29, September 2024)
        [ObservableProperty]
        private string _longDate;

        // (e.g., 29/09/2024)
        [ObservableProperty]
        private string _shortDate;

        // (e.g., 20240929)

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

        protected async Task ShowToastAsync(
            string message,
            ToastDuration duration = ToastDuration.Long,
            double fontSize = 14
        )
        {
            await ToastService.ShowToastAsync(message, duration, fontSize);
        }

        private void UpdateDateFormats()
        {
            LongDate = CurrentDateTime.ToString("dd, MMMM yyyy");
            ShortDate = CurrentDateTime.ToString("dd/MM/yyyy");
            TimeOnly = CurrentDateTime.ToString("HH:mm");
            ShortPreviousDate = CurrentDateTime.AddDays(-1).ToString("dd/MM/yyyy");
        }

        partial void OnCurrentDateTimeChanged(DateTime value)
        {
            UpdateDateFormats();
        }
    }
}
