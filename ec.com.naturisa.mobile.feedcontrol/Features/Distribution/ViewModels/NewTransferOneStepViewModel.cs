namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewTransferOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private WarehouseTransferRequest warehouseTransfer;

        [ObservableProperty]
        private int originWarehouseId = 64;

        [ObservableProperty]
        private ObservableCollection<WarehouseResponse> warehouses;

        [ObservableProperty]
        private WarehouseResponse originWarehouse;

        [ObservableProperty]
        private List<string> destinationBranches;

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
        private WarehouseResponse destinationWarehouse;

        [ObservableProperty]
        private string selectedTransporter;

        [ObservableProperty]
        private string selectedVehiclePlate;

        public NewTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            OriginWarehouse = new WarehouseResponse
            {
                IdWarehouse = 64,
                Name = "Acopio Pezjoya"

            };

            // 64 AC
            // 49 FINCA

            destinationBranches = ["Naturisa"];

            Warehouses = new ObservableCollection<WarehouseResponse>
            {
                new WarehouseResponse
                {
                    IdWarehouse = 49,
                    Name = "Bodega de Balanceado"
                }
            };

            transporters = ["NELSON ZAMBRANO"];
            vehiclePlates = ["GRZ 6396"];
        }

        #region commands        
        [RelayCommand]
        async Task GoToTwoStep()
        {
           // if (
           //    string.IsNullOrEmpty(SelectedDestinationBranch)
           //    || string.IsNullOrEmpty(SelectedTransporter)
           //    || string.IsNullOrEmpty(SelectedVehiclePlate)
           //)
           // {
           //     await ToastService.ShowToastAsync("Por favor complete todos los campos");
           //     return;
           // }

            WarehouseTransfer = new WarehouseTransferRequest
            {
                OriginWarehouseId = OriginWarehouse.IdWarehouse,
                DestinationWarehouseId = DestinationWarehouse.IdWarehouse,
                FreightTransporterId = 16,
                TransportId = 24
            };

            await Shell.Current.GoToAsync(nameof(NewTransferTwoStepView),
                true,
                new Dictionary<string, object> {                   
                    ["WarehouseTransfer"] = WarehouseTransfer,
                    ["OriginWarehouse"] = OriginWarehouse,
                    ["DestinationWarehouse"] = DestinationWarehouse,
                }
                );
        }
        #endregion
    }
}
