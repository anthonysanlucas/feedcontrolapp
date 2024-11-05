namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    [QueryProperty(nameof(PoolCode), "poolCode")]
    public partial class FeedingRemainingDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isBtnVisible = true;

        [ObservableProperty]
        private string poolCode;

        public FeedingRemainingDetailViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToFeedingRemaining()
        {
            IsBtnVisible = false;
            IsBusy = true;

            await Task.Delay(2000);

            await ShowToastAsync("Sobrante registrado correctamente");

            await Shell.Current.Navigation.PopAsync(true);
        }
    }
}
