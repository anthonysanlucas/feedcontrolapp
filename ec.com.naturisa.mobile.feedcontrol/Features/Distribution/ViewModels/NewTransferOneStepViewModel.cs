using ec.com.naturisa.mobile.feedcontrol.Models.Warehouse;

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
        private WarehouseResponse originBranch;

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
        private WarehouseResponse selectedDestinationWharehouse;

        [ObservableProperty]
        private string selectedTransporter;

        [ObservableProperty]
        private string selectedVehiclePlate;

        public NewTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            OriginBranch = new WarehouseResponse
            {
                IdWarehouse = 64,
                Name = "Bodega de Balanceado"

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
        async Task SubmitTransfer()
        {
            if (
                string.IsNullOrEmpty(SelectedDestinationBranch)
                || string.IsNullOrEmpty(SelectedTransporter)
                || string.IsNullOrEmpty(SelectedVehiclePlate)
            )
            {
                await ToastService.ShowToastAsync("Por favor complete todos los campos");
                return;
            }

            await Shell.Current.GoToAsync(nameof(NewTransferTwoStepView));
        }

        [RelayCommand]
        async Task GoToTwoStep()
        {
            WarehouseTransfer = new WarehouseTransferRequest
            {
                OriginWarehouseId = OriginBranch.IdWarehouse,
                DestinationWarehouseId = SelectedDestinationWharehouse.IdWarehouse,
                FreightTransporterId = 16,
                TransportId = 24
            };

            await Shell.Current.GoToAsync(nameof(NewTransferTwoStepView),
                true,
                new Dictionary<string, object> { { nameof(WarehouseTransfer), WarehouseTransfer } }
                );
        }
        #endregion
    }
}
