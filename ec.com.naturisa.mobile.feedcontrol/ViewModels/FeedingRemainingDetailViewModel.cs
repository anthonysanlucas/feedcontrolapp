namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    [QueryProperty(nameof(PoolCode), "poolCode")]
    public partial class FeedingRemainingDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isBtnVisible = true;

        [ObservableProperty]
        private string poolCode;

        // Cambiar a tipos int? para permitir valores nulos
        [ObservableProperty]
        private int? remainingSacks;

        [ObservableProperty]
        private int? remainingHoppers;

        public FeedingRemainingDetailViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToFeedingRemaining()
        {
            // Validación de valores nulos en lugar de 0
            if (RemainingSacks == null || RemainingHoppers == null)
            {
                await ShowToastAsync("Por favor, ingrese todos los datos");
                return;
            }

            IsBtnVisible = false;
            IsBusy = true;

            await Task.Delay(2000);

            await ShowToastAsync("Sobrante registrado correctamente");

            await Shell.Current.Navigation.PopAsync(true);

            IsBtnVisible = true;
            IsBusy = false;
        }
    }
}
