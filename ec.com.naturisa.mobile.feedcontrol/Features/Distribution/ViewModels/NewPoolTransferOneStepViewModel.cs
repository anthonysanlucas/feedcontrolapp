namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewPoolTransferOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<string> availablePools;

        [ObservableProperty]
        private string originBranch;

        [ObservableProperty]
        private List<string> originWarehouses;

        [ObservableProperty]
        private List<string> transporters;

        [ObservableProperty]
        private List<string> vehiclePlates;

        [ObservableProperty]
        private string selectedOriginWharehouse;

        [ObservableProperty]
        private string selectedTransporter;

        [ObservableProperty]
        private string selectedVehiclePlate;

        public NewPoolTransferOneStepViewModel(IToastService toastService)
            : base(toastService)
        {
            OriginBranch = "MARICULTURA";

            originWarehouses = ["Bodega de Balanceado"];

            transporters = ["NELSON ZAMBRANO"];
            vehiclePlates = ["GCT 5936"];
        }

        [RelayCommand]
        async Task GoToPoolTransferTwoStep()
        {
            await Shell.Current.GoToAsync(nameof(NewPoolTransferTwoStepView));
        }

        private void SortAvailablePools()
        {
            var sortedPools = AvailablePools.OrderBy(p => p).ToList();

            // Limpiar la colección actual y agregar los elementos ordenados
            AvailablePools.Clear();
            foreach (var pool in sortedPools)
            {
                AvailablePools.Add(pool);
            }
        }
    }
}
