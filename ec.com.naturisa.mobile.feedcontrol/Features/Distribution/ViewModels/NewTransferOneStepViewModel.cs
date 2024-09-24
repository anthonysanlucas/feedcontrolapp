namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewTransferOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<string> destinationTypes;

        [ObservableProperty]
        private List<string> destinations;

        [ObservableProperty]
        private List<string> carriers;

        [ObservableProperty]
        private List<string> vehicles;

        [ObservableProperty]
        private string selectedDestinationType;

        [ObservableProperty]
        private string selectedDestination;

        [ObservableProperty]
        private string selectedCarrier;

        [ObservableProperty]
        private string selectedVehicle;

        public NewTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            DestinationTypes = new List<string> { "BODEGA", "PISCINA" };
            Destinations = new List<string>
            {
                "MA001",
                "MA002",
                "MA003",
                "MA004",
                "MA005",
                "MA006",
                "MA007",
                "MA007",
                "MA008"
            };
            Carriers = new List<string> { "NELSON ZAMBRANO" };
            Vehicles = new List<string> { "GCT 5936" };
        }

        [RelayCommand]
        async Task SubmitTransfer()
        {
            if (
                string.IsNullOrEmpty(SelectedDestinationType)
                || string.IsNullOrEmpty(SelectedDestination)
                || string.IsNullOrEmpty(SelectedCarrier)
                || string.IsNullOrEmpty(SelectedVehicle)
            )
            {
                await ToastService.ShowToastAsync("Por favor complete todos los campos.");
                return;
            }

            await Shell.Current.GoToAsync(nameof(NewTransferTwoStepView));
        }
    }
}
