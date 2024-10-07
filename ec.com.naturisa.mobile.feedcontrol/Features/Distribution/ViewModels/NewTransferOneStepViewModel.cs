namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewTransferOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<string> destinationTypes;

        [ObservableProperty]
        private string originBranch;

        [ObservableProperty]
        private List<string> originWarehouses;

        [ObservableProperty]
        private List<string> destinationBranches;

        [ObservableProperty]
        private List<string> destinationWarehouses;

        [ObservableProperty]
        private List<string> destinations;

        [ObservableProperty]
        private List<string> transporters;

        [ObservableProperty]
        private List<string> vehiclePlates;

        [ObservableProperty]
        private string selectedDestinationType;

        [ObservableProperty]
        private string selectedOriginWharehouse;

        [ObservableProperty]
        private string selectedDestinationBranch;

        [ObservableProperty]
        private string selectedDestinationWharehouse;

        [ObservableProperty]
        private string selectedTransporter;

        [ObservableProperty]
        private string selectedVehiclePlate;

        public NewTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            originBranch = "MARICULTURA";

            originWarehouses = ["Bodega de Balanceado"];

            destinationBranches = ["Kamaclusa"];

            destinationWarehouses = ["Bodega de Balanceado"];

            transporters = ["NELSON ZAMBRANO"];
            vehiclePlates = ["GCT 5936"];
        }

        [RelayCommand]
        async Task SubmitTransfer()
        {
            if (
                string.IsNullOrEmpty(SelectedOriginWharehouse)
                || string.IsNullOrEmpty(SelectedDestinationBranch)
                || string.IsNullOrEmpty(SelectedDestinationWharehouse)
                || string.IsNullOrEmpty(SelectedTransporter)
                || string.IsNullOrEmpty(SelectedVehiclePlate)
            )
            {
                await ToastService.ShowToastAsync("Por favor complete todos los campos");
                return;
            }

            await Shell.Current.GoToAsync(nameof(NewTransferTwoStepView));
        }
    }
}
